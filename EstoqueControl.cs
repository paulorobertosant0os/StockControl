using System.Globalization;
using StockControl.Data;
using StockControl.Models;

namespace StockControl
{
    public partial class EstoqueControl : UserControl
    {
        private readonly ProdutoRepositorio _repositorio = new();

        public EstoqueControl()
        {
            InitializeComponent();

            ConfigurarGrid();
            Estilizar();

            numEstoqueMinimo.Value = ConfiguracaoEstoque.Minimo;

            Recarregar();
        }

        public void Recarregar()
        {
            var exibidos = _repositorio.Listar()
                .Where(p => p.Nome.Contains(txtPesquisa.Text, StringComparison.OrdinalIgnoreCase))
                .ToList();

            gridEstoque.DataSource = null;
            gridEstoque.DataSource = exibidos;
            lblRodape.Text = $"{exibidos.Count} produto(s)";
        }

        private void ConfigurarGrid()
        {
            gridEstoque.AutoGenerateColumns = false;
            gridEstoque.Columns.Clear();

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

            gridEstoque.Columns.Add(colNome);
            gridEstoque.Columns.Add(colPreco);
            gridEstoque.Columns.Add(colQuantidade);

            gridEstoque.CellFormatting += GridEstoque_CellFormatting;
        }

        private void GridEstoque_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || gridEstoque.Rows[e.RowIndex].DataBoundItem is not Produto produto)
            {
                return;
            }

            if (produto.Quantidade < (int)numEstoqueMinimo.Value)
            {
                e.CellStyle!.ForeColor = Tema.Alerta;
            }
        }

        private void Estilizar()
        {
            BackColor = Tema.Fundo;

            foreach (var rotulo in new[] { lblPesquisar, lblMinimo })
            {
                Tema.EstilizarRotulo(rotulo);
            }

            lblRodape.ForeColor = Tema.TextoSuave;
            lblRodape.Font = Tema.Fonte(8.5F);

            Tema.EstilizarCampo(txtPesquisa);
            Tema.EstilizarBotaoSecundario(btnAtualizar);
            Tema.EstilizarGrade(gridEstoque);
        }

        private void txtPesquisa_TextChanged_1(object sender, EventArgs e) => Recarregar();

        private void numEstoqueMinimo_ValueChanged_1(object sender, EventArgs e)
        {
            ConfiguracaoEstoque.Minimo = (int)numEstoqueMinimo.Value;
            gridEstoque.Invalidate();
        }

        private void btnAtualizar_Click_1(object sender, EventArgs e) => Recarregar();
    }
}
