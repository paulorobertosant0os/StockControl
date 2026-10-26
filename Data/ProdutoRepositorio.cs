using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using StockControl.Data;
using StockControl.Models;
using System.Data;

namespace StockControl.Data
{
    /// <summary>
    /// Lançada quando o produto possui movimentações e a exclusão simples
    /// é bloqueada pela chave estrangeira do banco.
    /// </summary>
    internal class ProdutoComMovimentacoesException : Exception
    {
        public ProdutoComMovimentacoesException(int produtoId, int movimentacoes, Exception? interna = null)
            : base("Este produto possui movimentações registradas e não pode ser excluído.", interna)
        {
            ProdutoId = produtoId;
            Movimentacoes = movimentacoes;
        }

        public int ProdutoId { get; }

        public int Movimentacoes { get; }
    }

    internal class ProdutoRepositorio
    {
        public List<Produto> Listar()
        {
            const string sql = @"SELECT Id, Nome, Preco, Quantidade FROM dbo.Produtos ORDER BY Nome;";

            var produtos = new List<Produto>();

            using var conexao = new SqlConnection(Conexao.StringConexao);
            using var comando = new SqlCommand(sql, conexao);

            conexao.Open();

            using var leitor = comando.ExecuteReader();

            while(leitor.Read())
            {
                produtos.Add(new Produto
                {
                    Id = leitor.GetInt32(0),
                    Nome = leitor.GetString(1),
                    Preco = leitor.GetDecimal(2),
                    Quantidade = leitor.GetInt32(3)
                });
                
            }

            return produtos;
        }

        public int Inserir(Produto produto)
        {
            const string sql = @"INSERT INTO dbo.Produtos (Nome, Preco, Quantidade)
                                OUTPUT INSERTED.ID
                                VALUES (@Nome, @Preco, @Quantidade);";

            using var conexao = new SqlConnection(Conexao.StringConexao);
            using var comando = new SqlCommand(sql, conexao);
            comando.Parameters.Add(new SqlParameter("@Nome", SqlDbType.NVarChar, 150) { Value = produto.Nome});
            comando.Parameters.Add(new SqlParameter("@Preco", SqlDbType.Decimal) { Precision = 10, Scale = 2, Value = produto.Preco });
            comando.Parameters.Add(new SqlParameter("@Quantidade", SqlDbType.Int) { Value = produto.Quantidade });

            conexao.Open();

            produto.Id = (int)comando.ExecuteScalar()!;
            return produto.Id;
        }

        public int Atualizar(Produto produto)
        {
            const string sql = @"UPDATE dbo.Produtos SET Nome = @Nome, Preco = @Preco, Quantidade = @Quantidade WHERE Id = @Id;";
            using var conexao = new SqlConnection(Conexao.StringConexao);
            using var comando = new SqlCommand(sql, conexao);

            comando.Parameters.Add(new SqlParameter("@Nome", SqlDbType.NVarChar, 150) { Value = produto.Nome });
            comando.Parameters.Add(new SqlParameter("@Preco", SqlDbType.Decimal) { Precision = 10, Scale = 2, Value = produto.Preco });
            comando.Parameters.Add(new SqlParameter("@Quantidade", SqlDbType.Int) { Value = produto.Quantidade });
            comando.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = produto.Id });
            conexao.Open();
            return comando.ExecuteNonQuery();

        }
        
        public int Excluir(int id)
        {
            const string sql = @"DELETE FROM dbo.Produtos WHERE Id = @Id;";

            using var conexao = new SqlConnection(Conexao.StringConexao);
            using var comando = new SqlCommand(sql, conexao);
            comando.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id});

            conexao.Open();

            try
            {
                return comando.ExecuteNonQuery();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                // Chave estrangeira de Movimentacoes -> Produtos (NO ACTION).
                int movimentacoes = 0;

                try
                {
                    movimentacoes = ContarMovimentacoes(id);
                }
                catch (SqlException)
                {
                    // Se a contagem falhar, a mensagem ainda informa o bloqueio.
                }

                throw new ProdutoComMovimentacoesException(id, movimentacoes, ex);
            }
        }

        public int ContarMovimentacoes(int produtoId)
        {
            const string sql = @"SELECT COUNT(1) FROM dbo.Movimentacoes WHERE ProdutoId = @ProdutoId;";

            using var conexao = new SqlConnection(Conexao.StringConexao);
            using var comando = new SqlCommand(sql, conexao);
            comando.Parameters.Add(new SqlParameter("@ProdutoId", SqlDbType.Int) { Value = produtoId });

            conexao.Open();
            return (int)comando.ExecuteScalar()!;
        }

        /// <summary>
        /// Exclui o produto e todo o seu histórico de movimentações em uma única transação.
        /// </summary>
        public int ExcluirComMovimentacoes(int produtoId)
        {
            using var conexao = new SqlConnection(Conexao.StringConexao);
            conexao.Open();
            using var transacao = conexao.BeginTransaction();

            try
            {
                using (var comandoMovimentacoes = new SqlCommand(
                    @"DELETE FROM dbo.Movimentacoes WHERE ProdutoId = @ProdutoId;", conexao, transacao))
                {
                    comandoMovimentacoes.Parameters.Add(new SqlParameter("@ProdutoId", SqlDbType.Int) { Value = produtoId });
                    comandoMovimentacoes.ExecuteNonQuery();
                }

                int removidos;

                using (var comandoProduto = new SqlCommand(
                    @"DELETE FROM dbo.Produtos WHERE Id = @Id;", conexao, transacao))
                {
                    comandoProduto.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = produtoId });
                    removidos = comandoProduto.ExecuteNonQuery();
                }

                transacao.Commit();
                return removidos;
            }
            catch (Exception)
            {
                transacao.Rollback();
                throw;
            }
        }

    }
}
