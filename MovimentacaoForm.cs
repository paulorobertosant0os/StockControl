using System.Globalization;
using StockControl.Data;
using StockControl.Models;

namespace StockControl
{
    public partial class MovimentacaoForm : Form
    {
        private static readonly CultureInfo CulturaBr = CultureInfo.GetCultureInfo("pt-BR");

        private readonly MovimentacaoRepositorio _repositorio = new();

        public MovimentacaoForm(List<Produto> produtos)
        {
            InitializeComponent();
            Tema.PrepararFormulario(this);

            Estilizar();

            cmbProduto.DataSource = produtos;
            cmbProduto.DisplayMember = nameof(Produto.Nome);
            cmbProduto.ValueMember = nameof(Produto.Id);

            AtualizarTipo();
            AtualizarSaldo();

            txtQuantidade.Text = "1";

            Shown += (_, _) =>
            {
                txtQuantidade.Focus();
                txtQuantidade.SelectAll();
            };
        }

        private void Estilizar()
        {
            panelCabecalho.BackColor = Tema.Sidebar;
            panelRodape.BackColor = Tema.Sidebar;
            panelLinhaCabecalho.BackColor = Tema.Borda;
            panelLinhaRodape.BackColor = Tema.Borda;
            panelAcento.BackColor = Tema.Acento;

            lblTitulo.ForeColor = Tema.Texto;
            lblTitulo.Font = Tema.Fonte(16F, FontStyle.Bold);

            lblSubtitulo.ForeColor = Tema.TextoSuave;
            lblSubtitulo.Font = Tema.Fonte(9F);

            foreach (var rotulo in new[] { label1, label2, label3, label4 })
            {
                Tema.EstilizarRotulo(rotulo);
            }

            lblSaldo.ForeColor = Tema.TextoSuave;
            lblSaldo.Font = Tema.Fonte(8.5F);

            Tema.EstilizarCampo(txtQuantidade);
            Tema.EstilizarCampo(txtObservacao);

            Tema.EstilizarBotaoPrimario(btnSalvar);
            Tema.EstilizarBotaoSecundario(btnCancelar);

            lblErro.ForeColor = Tema.Alerta;
            lblErro.Font = Tema.Fonte(9F);

            EstilizarCartaoTipo(panelEntrada, rbEntrada, lblEntradaDescricao);
            EstilizarCartaoTipo(panelSaida, rbSaida, lblSaidaDescricao);

            panelEntrada.Paint += (_, e) => DesenharBorda(panelEntrada, e, rbEntrada.Checked);
            panelSaida.Paint += (_, e) => DesenharBorda(panelSaida, e, rbSaida.Checked);

            panelEntrada.Click += (_, _) => rbEntrada.Checked = true;
            panelSaida.Click += (_, _) => rbSaida.Checked = true;
            lblEntradaDescricao.Click += (_, _) => rbEntrada.Checked = true;
            lblSaidaDescricao.Click += (_, _) => rbSaida.Checked = true;
        }

        private void EstilizarCartaoTipo(Panel painel, RadioButton opcao, Label descricao)
        {
            painel.BackColor = Tema.Cartao;
            painel.Cursor = Cursors.Hand;

            opcao.BackColor = Color.Transparent;
            opcao.ForeColor = Tema.Texto;
            opcao.FlatStyle = FlatStyle.Flat;
            opcao.Font = Tema.Fonte(10F, FontStyle.Bold);
            opcao.Cursor = Cursors.Hand;

            descricao.BackColor = Color.Transparent;
            descricao.ForeColor = Tema.TextoSuave;
            descricao.Font = Tema.Fonte(8.5F);
            descricao.Cursor = Cursors.Hand;
        }

        private void AtualizarTipo()
        {
            bool entrada = rbEntrada.Checked;

            panelEntrada.BackColor = entrada ? Tema.Hover : Tema.Cartao;
            panelSaida.BackColor = entrada ? Tema.Cartao : Tema.Hover;

            rbEntrada.ForeColor = entrada ? Tema.Sucesso : Tema.Texto;
            rbSaida.ForeColor = entrada ? Tema.Texto : Tema.Alerta;

            lblEntradaDescricao.ForeColor = entrada ? Tema.Texto : Tema.TextoSuave;
            lblSaidaDescricao.ForeColor = entrada ? Tema.TextoSuave : Tema.Texto;

            panelEntrada.Invalidate();
            panelSaida.Invalidate();
        }

        private void AtualizarSaldo()
        {
            if (cmbProduto.SelectedItem is not Produto produto)
            {
                lblSaldo.Text = "Selecione um produto para consultar o saldo.";
                lblSaldo.ForeColor = Tema.TextoSuave;
                return;
            }

            lblSaldo.Text = $"Estoque atual: {FormatarUnidades(produto.Quantidade)}";
            lblSaldo.ForeColor = produto.Quantidade < ConfiguracaoEstoque.Minimo
                ? Tema.Alerta
                : Tema.TextoSuave;
        }

        private void cmbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarSaldo();
            LimparErro();
        }

        private void rbTipo_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarTipo();
            LimparErro();
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e) => LimparErro();

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            LimparErro();

            if (cmbProduto.SelectedItem is not Produto produto)
            {
                MostrarErro("Selecione um produto para movimentar.", cmbProduto);
                return;
            }

            if (!int.TryParse(
                    txtQuantidade.Text.Trim(),
                    NumberStyles.Integer | NumberStyles.AllowThousands,
                    CulturaBr,
                    out int quantidade)
                || quantidade <= 0)
            {
                MostrarErro("Informe uma quantidade maior que zero.", txtQuantidade);
                return;
            }

            var tipo = rbEntrada.Checked ? TipoMovimentacao.Entrada : TipoMovimentacao.Saida;

            if (tipo == TipoMovimentacao.Saida && quantidade > produto.Quantidade)
            {
                MostrarErro(
                    $"Estoque insuficiente: o saldo atual é de {FormatarUnidades(produto.Quantidade)}.",
                    txtQuantidade);
                return;
            }

            try
            {
                _repositorio.Movimentar(produto.Id, tipo, quantidade, txtObservacao.Text);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (EstoqueInsuficienteException ex)
            {
                MostrarErro(ex.Message, txtQuantidade);
            }
            catch (Exception ex)
            {
                Tema.MostrarErro(
                    this,
                    "Movimentação não realizada",
                    "Não foi possível concluir a movimentação. Verifique a conexão com o banco de dados.\n\nDetalhes: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void MostrarErro(string mensagem, Control campo)
        {
            lblErro.Text = "!  " + mensagem;
            lblErro.Visible = true;
            campo.Focus();

            if (campo is TextBoxBase texto)
            {
                texto.SelectAll();
            }
        }

        private void LimparErro()
        {
            if (!lblErro.Visible)
            {
                return;
            }

            lblErro.Text = string.Empty;
            lblErro.Visible = false;
        }

        private static void DesenharBorda(Panel painel, PaintEventArgs e, bool selecionado)
        {
            ControlPaint.DrawBorder(
                e.Graphics,
                painel.ClientRectangle,
                selecionado ? Tema.Acento : Tema.Borda,
                ButtonBorderStyle.Solid);
        }

        private static string FormatarUnidades(int quantidade)
            => quantidade == 1 ? "1 unidade" : $"{quantidade} unidades";
    }
}
