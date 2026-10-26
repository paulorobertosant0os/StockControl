using StockControl.Data;
using StockControl.Models;

namespace StockControl
{
    public partial class MovimentacoesControl : UserControl
    {
        private readonly ProdutoRepositorio _produtoRepositorio = new();
        private readonly MovimentacaoRepositorio _movimentacaoRepositorio = new();

        public MovimentacoesControl()
        {
            InitializeComponent();

            cboTipo.Items.AddRange(new object[] { "Entrada", "Saída" });
            cboTipo.SelectedIndex = 0;

            ConfigurarGrid();
            Estilizar();
            Recarregar();
        }

        public void Recarregar()
        {
            int selecionarId = (cboProduto.SelectedItem as Produto)?.Id ?? 0;

            var produtos = _produtoRepositorio.Listar();
            cboProduto.DataSource = null;
            cboProduto.DisplayMember = nameof(Produto.Nome);
            cboProduto.ValueMember = nameof(Produto.Id);
            cboProduto.DataSource = produtos;

            if (selecionarId != 0)
            {
                cboProduto.SelectedValue = selecionarId;
            }

            var movimentacoes = _movimentacaoRepositorio.ListarRecentes();
            gridMovimentacoes.DataSource = null;
            gridMovimentacoes.DataSource = movimentacoes;
            lblRodape.Text = $"{movimentacoes.Count} movimentação(ões)";
        }

        private void ConfigurarGrid()
        {
            gridMovimentacoes.AutoGenerateColumns = false;
            gridMovimentacoes.Columns.Clear();

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
                FillWeight = 38F,
                ReadOnly = true
            };

            var colTipo = new DataGridViewTextBoxColumn
            {
                Name = "colTipo",
                HeaderText = "Tipo",
                DataPropertyName = nameof(Movimentacao.TipoDescricao),
                FillWeight = 14F,
                ReadOnly = true
            };

            var colQuantidade = new DataGridViewTextBoxColumn
            {
                Name = "colQuantidade",
                HeaderText = "Quantidade",
                DataPropertyName = nameof(Movimentacao.Quantidade),
                FillWeight = 12F,
                ReadOnly = true
            };
            colQuantidade.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var colObservacao = new DataGridViewTextBoxColumn
            {
                Name = "colObservacao",
                HeaderText = "Observação",
                DataPropertyName = nameof(Movimentacao.Observacao),
                FillWeight = 34F,
                ReadOnly = true
            };

            gridMovimentacoes.Columns.Add(colData);
            gridMovimentacoes.Columns.Add(colProduto);
            gridMovimentacoes.Columns.Add(colTipo);
            gridMovimentacoes.Columns.Add(colQuantidade);
            gridMovimentacoes.Columns.Add(colObservacao);

            gridMovimentacoes.CellFormatting += GridMovimentacoes_CellFormatting;
        }

        private void GridMovimentacoes_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || gridMovimentacoes.Columns[e.ColumnIndex].Name != "colTipo"
                || gridMovimentacoes.Rows[e.RowIndex].DataBoundItem is not Movimentacao mov)
            {
                return;
            }

            e.CellStyle!.ForeColor = mov.Tipo == TipoMovimentacao.Entrada ? Tema.Sucesso : Tema.Alerta;
        }

        private void Estilizar()
        {
            BackColor = Tema.Fundo;

            btnRegistrar.Text = "Registrar movimentação";

            Tema.EstilizarBotaoPrimario(btnRegistrar);

            foreach (var rotulo in new[] { lblProduto, lblTipo, lblQuantidade, lblObservacao })
            {
                Tema.EstilizarRotulo(rotulo);
            }

            lblRodape.ForeColor = Tema.TextoSuave;
            lblRodape.Font = Tema.Fonte(8.5F);

            Tema.EstilizarCampo(txtObservacao);
            Tema.EstilizarGrade(gridMovimentacoes);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cboProduto.SelectedItem is not Produto produto)
            {
                Tema.MostrarAviso(
                    this,
                    "Nenhum produto selecionado",
                    "Selecione um produto para registrar a movimentação.");
                return;
            }

            int quantidade = (int)numQuantidade.Value;

            if (quantidade <= 0)
            {
                Tema.MostrarAviso(
                    this,
                    "Quantidade inválida",
                    "Informe uma quantidade maior que zero.");

                numQuantidade.Focus();
                return;
            }

            var tipo = cboTipo.SelectedIndex == 0 ? TipoMovimentacao.Entrada : TipoMovimentacao.Saida;
            string? observacao = string.IsNullOrWhiteSpace(txtObservacao.Text) ? null : txtObservacao.Text.Trim();

            try
            {
                _movimentacaoRepositorio.Movimentar(produto.Id, tipo, quantidade, observacao);

                txtObservacao.Clear();
                numQuantidade.Value = numQuantidade.Minimum;
                Recarregar();
            }
            catch (EstoqueInsuficienteException ex)
            {
                Tema.MostrarAviso(this, "Estoque insuficiente", ex.Message);
            }
            catch (Exception ex)
            {
                Tema.MostrarErro(
                    this,
                    "Movimentação não realizada",
                    "Não foi possível concluir a movimentação. Verifique a conexão com o banco de dados.\n\nDetalhes: " + ex.Message);
            }
        }
    }
}
