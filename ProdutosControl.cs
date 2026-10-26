using System.Globalization;
using StockControl.Data;
using StockControl.Models;

namespace StockControl
{
    public partial class ProdutosControl : UserControl
    {
        private readonly ProdutoRepositorio _repositorio = new();

        public ProdutosControl()
        {
            InitializeComponent();

            ConfigurarGrid();
            Estilizar();

            Recarregar();
        }

        public void Recarregar()
        {
            var produtos = _repositorio.Listar();

            gridProdutos.DataSource = null;
            gridProdutos.DataSource = produtos;

            lblRodape.Text = $"{produtos.Count} produto(s)";
        }

        private void ConfigurarGrid()
        {
            gridProdutos.AutoGenerateColumns = false;
            gridProdutos.Columns.Clear();

            var colNome = new DataGridViewTextBoxColumn
            {
                Name = "colNome",
                HeaderText = "Nome",
                DataPropertyName = nameof(Produto.Nome),
                FillWeight = 55F,
                ReadOnly = true
            };

            var colPreco = new DataGridViewTextBoxColumn
            {
                Name = "colPreco",
                HeaderText = "Preço",
                DataPropertyName = nameof(Produto.Preco),
                FillWeight = 22F,
                ReadOnly = true
            };

            colPreco.DefaultCellStyle.Format = "C2";
            colPreco.DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            colPreco.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var colQuantidade = new DataGridViewTextBoxColumn
            {
                Name = "colQuantidade",
                HeaderText = "Quantidade",
                DataPropertyName = nameof(Produto.Quantidade),
                FillWeight = 23F,
                ReadOnly = true
            };

            colQuantidade.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gridProdutos.Columns.Add(colNome);
            gridProdutos.Columns.Add(colPreco);
            gridProdutos.Columns.Add(colQuantidade);
        }

        private void Estilizar()
        {
            BackColor = Tema.Fundo;

            Tema.EstilizarBotaoPrimario(btnNovo);
            Tema.EstilizarBotaoSecundario(btnEditar);
            Tema.EstilizarBotaoSecundario(btnExcluir);
            Tema.EstilizarBotaoSecundario(btnMovimentar);

            btnExcluir.ForeColor = Tema.Alerta;

            lblRodape.ForeColor = Tema.TextoSuave;
            lblRodape.Font = Tema.Fonte(8.5F);

            Tema.EstilizarGrade(gridProdutos);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            using var form = new ProdutoForm();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Recarregar();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridProdutos.CurrentRow?.DataBoundItem is not Produto produto)
            {
                Tema.MostrarAviso(
                    this,
                    "Nenhum produto selecionado",
                    "Selecione um produto na lista para editar.");
                return;
            }

            using var form = new ProdutoForm(produto);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Recarregar();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (gridProdutos.CurrentRow?.DataBoundItem is not Produto produto)
            {
                Tema.MostrarAviso(
                    this,
                    "Nenhum produto selecionado",
                    "Selecione um produto na lista para excluir.");
                return;
            }

            int movimentacoes;

            try
            {
                movimentacoes = _repositorio.ContarMovimentacoes(produto.Id);
            }
            catch (Exception erro)
            {
                Tema.MostrarErro(
                    this,
                    "Não foi possível excluir",
                    "Não foi possível consultar as movimentações do produto. Verifique a conexão com o banco de dados.\n\nDetalhes: " + erro.Message);
                return;
            }

            bool temHistorico = movimentacoes > 0;

            string historico = movimentacoes == 1
                ? "1 movimentação registrada"
                : $"{movimentacoes} movimentações registradas";

            string mensagem = temHistorico
                ? $"\"{produto.Nome}\" possui {historico}.\n\n" +
                  "Para excluir o produto, o histórico de movimentações dele também será apagado.\n\n" +
                  "Deseja continuar?"
                : $"Deseja excluir \"{produto.Nome}\"?\n\nEssa ação não pode ser desfeita.";

            bool confirmado = Tema.Confirmar(
                this,
                temHistorico ? "Produto com movimentações" : "Excluir produto",
                mensagem,
                temHistorico ? "Excluir produto e histórico" : "Excluir",
                destrutivo: true);

            if (!confirmado)
            {
                return;
            }

            try
            {
                if (temHistorico)
                {
                    _repositorio.ExcluirComMovimentacoes(produto.Id);
                }
                else
                {
                    _repositorio.Excluir(produto.Id);
                }

                Recarregar();
            }
            catch (ProdutoComMovimentacoesException)
            {
                Tema.MostrarAviso(
                    this,
                    "Movimentações registradas",
                    "Este produto recebeu movimentações enquanto a exclusão era preparada e não foi excluído.\n\n" +
                    "Tente novamente para excluir o produto junto com o histórico.");
            }
            catch (Exception erro)
            {
                Tema.MostrarErro(
                    this,
                    "Não foi possível excluir",
                    "O produto não foi excluído. Verifique a conexão com o banco de dados.\n\nDetalhes: " + erro.Message);
            }
        }

        private void btnMovimentar_Click(object sender, EventArgs e)
        {
            var produtos = _repositorio.Listar();

            if (produtos.Count == 0)
            {
                Tema.MostrarInformacao(
                    this,
                    "Nenhum produto cadastrado",
                    "Cadastre um produto antes de registrar uma movimentação.");
                return;
            }

            using var form = new MovimentacaoForm(produtos);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Recarregar();
            }
        }
    }
}
