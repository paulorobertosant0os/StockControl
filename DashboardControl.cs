using StockControl.Data;
using StockControl.Models;

namespace StockControl
{
    public partial class DashboardControl : UserControl
    {
        private readonly DashboardRepositorio _repositorio = new();


        public DashboardControl()
        {
            InitializeComponent();

            ConfigurarGrid();
            Estilizar();
            Recarregar();
        }

        public void Recarregar()
        {
            var resumo = _repositorio.ObterResumo(ConfiguracaoEstoque.Minimo);

            lblTotalValor.Text = resumo.TotalProdutosAtivos.ToString("N0");
            lblItensValor.Text = resumo.TotalUnidadesEmEstoque.ToString("N0");
            lblBaixoValor.Text = resumo.ProdutosEstoqueBaixo.ToString("N0");
            lblBaixoRotulo.Text = $"Estoque baixo (limite: {ConfiguracaoEstoque.Minimo})";

            gridRecentes.DataSource = null;
            gridRecentes.DataSource = resumo.MovimentacoesRecentes;
        }

        private void ConfigurarGrid()
        {
            gridRecentes.AutoGenerateColumns = false;
            gridRecentes.Columns.Clear();

            var colData = new DataGridViewTextBoxColumn
            {
                Name = "colData",
                HeaderText = "Data",
                DataPropertyName = nameof(Movimentacao.Data),
                FillWeight = 22F,
                ReadOnly = true
            };
            colData.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            var colProduto = new DataGridViewTextBoxColumn
            {
                Name = "colProduto",
                HeaderText = "Produto",
                DataPropertyName = nameof(Movimentacao.ProdutoNome),
                FillWeight = 46F,
                ReadOnly = true
            };

            var colTipo = new DataGridViewTextBoxColumn
            {
                Name = "colTipo",
                HeaderText = "Tipo",
                DataPropertyName = nameof(Movimentacao.TipoDescricao),
                FillWeight = 16F,
                ReadOnly = true
            };

            var colQuantidade = new DataGridViewTextBoxColumn
            {
                Name = "colQuantidade",
                HeaderText = "Quantidade",
                DataPropertyName = nameof(Movimentacao.Quantidade),
                FillWeight = 16F,
                ReadOnly = true
            };
            colQuantidade.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gridRecentes.Columns.Add(colData);
            gridRecentes.Columns.Add(colProduto);
            gridRecentes.Columns.Add(colTipo);
            gridRecentes.Columns.Add(colQuantidade);

            gridRecentes.CellFormatting += GridRecentes_CellFormatting;
        }

        private void GridRecentes_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || gridRecentes.Columns[e.ColumnIndex].Name != "colTipo" ||
                gridRecentes.Rows[e.RowIndex].DataBoundItem is not Movimentacao mov)
            {
                return;
            }

            e.CellStyle!.ForeColor = mov.Tipo == TipoMovimentacao.Entrada ? Tema.Sucesso : Tema.Alerta;
        }
        private void Estilizar()
        {
            BackColor = Tema.Fundo;
            panelCards.BackColor = Tema.Fundo;

            foreach (var card in new[] { panelCard1, panelCard2, panelCard3 })
            {
                card.BackColor = Tema.Cartao;
            }

            foreach (var valor in new[] { lblTotalValor, lblItensValor, lblBaixoValor })
            {
                valor.ForeColor = Tema.Texto;
                valor.Font = Tema.Fonte(22F, FontStyle.Bold);
            }

            foreach (var rotulo in new[] { lblTotalRotulo, lblItensRotulo, lblBaixoRotulo })
            {
                rotulo.ForeColor = Tema.TextoSuave;
                rotulo.Font = Tema.Fonte(9F);
            }

            lblRecentes.ForeColor = Tema.Texto;
            lblRecentes.Font = Tema.Fonte(11F, FontStyle.Bold);

            Tema.EstilizarGrade(gridRecentes);
        }
    }
}




