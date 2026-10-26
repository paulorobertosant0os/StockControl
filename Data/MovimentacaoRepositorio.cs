using Microsoft.Data.SqlClient;
using StockControl.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace StockControl.Data
{
    internal class EstoqueInsuficienteException : Exception
    {
        public EstoqueInsuficienteException(string mensagem) : base(mensagem) { }
    }

    internal class MovimentacaoRepositorio
    {
        public int Movimentar(int produtoId, TipoMovimentacao tipo, int quantidade, string? observacao)
        {
            using var conexao = new SqlConnection(Conexao.StringConexao);
            conexao.Open();
            using var transacao = conexao.BeginTransaction();

            try
            {
                AtualizarSaldo(conexao, transacao, produtoId, tipo, quantidade, observacao);
                int id = RegistrarMovimentacao(conexao, transacao, produtoId, tipo, quantidade, observacao);
                transacao.Commit();
                return id;

            }
            catch (Exception)
            {
                transacao.Rollback();
                throw;
            }
        }


        public List<Movimentacao> ListarRecentes()
        {
            const string sql = @"
            SELECT m.Id, m.ProdutoId, p.Nome, m.Tipo, m.Quantidade, m.Data, m.Observacao
            FROM dbo.Movimentacoes m
            INNER JOIN dbo.Produtos p ON p.Id = m.ProdutoId
            ORDER BY m.Id DESC;";

            var movimentacoes = new List<Movimentacao>();

            using var conexao = new SqlConnection(Conexao.StringConexao);
            using var comando = new SqlCommand(sql, conexao);

            conexao.Open();
            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {

                movimentacoes.Add(new Movimentacao 
                {
                    Id = leitor.GetInt32(0),
                    ProdutoId = leitor.GetInt32(1),
                    ProdutoNome = leitor.GetString(2),
                    Tipo = (TipoMovimentacao)leitor.GetByte(3),
                    Quantidade = leitor.GetInt32(4),
                    Data = leitor.GetDateTime(5),
                    Observacao = leitor.IsDBNull(6) ? null : leitor.GetString(6)

                });
                
            }

            return movimentacoes;
        }

        private static void AtualizarSaldo(SqlConnection conexao, SqlTransaction transacao, int produtoId, TipoMovimentacao tipo, int quantidade, string? observacao)
        {
            string sql = tipo == TipoMovimentacao.Saida ? @"UPDATE dbo.Produtos SET Quantidade = Quantidade - @Qtd
                                                            WHERE Id = @ProdutoId AND Quantidade >= @Qtd;"
                                                        : @"UPDATE dbo.Produtos SET Quantidade = Quantidade + @Qtd
                                                            WHERE Id = @ProdutoId;";

            using var comando = new SqlCommand(sql, conexao, transacao);
            comando.Parameters.Add(new SqlParameter("@ProdutoId", SqlDbType.Int) { Value = produtoId });
            comando.Parameters.Add(new SqlParameter("@Qtd", SqlDbType.Int) { Value = quantidade });

            int linhasAfetadas = comando.ExecuteNonQuery();

            if (linhasAfetadas == 0)
            {
                throw new EstoqueInsuficienteException(
                    "Estoque insuficiente: a quantidade solicitada é maior que o saldo disponível");                                                                            
            }
        }

        private static int RegistrarMovimentacao(SqlConnection conexao, SqlTransaction transacao, int produtoId, TipoMovimentacao tipo, 
                                                int quantidade, string? observacao)
        {


            const string sql = @"INSERT INTO dbo.Movimentacoes (ProdutoId, Tipo, Quantidade, Observacao)
                                OUTPUT INSERTED.ID
                                VALUES(@ProdutoId, @Tipo, @Qtd, @Observacao);";

            using var comando = new SqlCommand(sql, conexao, transacao);
            comando.Parameters.Add(new SqlParameter("@ProdutoId", SqlDbType.Int) { Value = produtoId });
            comando.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.TinyInt) { Value = (byte)tipo });
            comando.Parameters.Add(new SqlParameter("@Qtd", SqlDbType.Int) { Value = quantidade });
            comando.Parameters.Add(new SqlParameter("@Observacao", SqlDbType.NVarChar, 200) { Value = string.IsNullOrWhiteSpace(observacao) ? DBNull.Value : observacao.Trim() });

            return (int)comando.ExecuteScalar()!;
        }

        

    }
}
