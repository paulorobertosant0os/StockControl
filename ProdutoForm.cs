using System.Globalization;
using StockControl.Data;
using StockControl.Models;

namespace StockControl
{
    public partial class ProdutoForm : Form
    {
        private static readonly CultureInfo CulturaBr = CultureInfo.GetCultureInfo("pt-BR");

        private readonly ProdutoRepositorio _repositorio = new();
        private readonly Produto _produto;
        private readonly bool _edicao;

        public ProdutoForm(Produto? produto = null)
        {
            InitializeComponent();
            Tema.PrepararFormulario(this);

            _edicao = produto is not null;
            _produto = produto ?? new Produto();

            ConfigurarTextos();
            Estilizar();
            PreencherCampos();
        }

        private void ConfigurarTextos()
        {
            Text = _edicao ? "Editar produto" : "Novo produto";
            lblTitulo.Text = Text;
            lblSubtitulo.Text = _edicao
                ? "Atualize os dados do produto selecionado."
                : "Cadastre um novo item no seu estoque.";

            btnSalvar.Text = _edicao ? "Salvar alterações" : "Cadastrar produto";
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

            foreach (var rotulo in new[] { label1, label2, labelquantidade })
            {
                Tema.EstilizarRotulo(rotulo);
            }

            foreach (var ajuda in new[] { lblAjudaPreco, lblAjudaQuantidade })
            {
                ajuda.ForeColor = Tema.TextoSuave;
                ajuda.Font = Tema.Fonte(8F);
            }

            lblErro.ForeColor = Tema.Alerta;
            lblErro.Font = Tema.Fonte(9F);

            Tema.EstilizarCampo(txtNome);
            Tema.EstilizarCampo(txtPreco);
            Tema.EstilizarCampo(txtQuantidade);

            Tema.EstilizarBotaoPrimario(btnSalvar);
            Tema.EstilizarBotaoSecundario(btnCancelar);

            txtNome.TextChanged += (_, _) => LimparErro();
            txtPreco.TextChanged += (_, _) => LimparErro();
            txtQuantidade.TextChanged += (_, _) => LimparErro();
        }

        private void PreencherCampos()
        {
            if (!_edicao)
            {
                txtQuantidade.Text = "0";
                return;
            }

            txtNome.Text = _produto.Nome;
            txtPreco.Text = _produto.Preco.ToString("N2", CulturaBr);
            txtQuantidade.Text = _produto.Quantidade.ToString(CulturaBr);
        }

        private void ProdutoForm_Load(object sender, EventArgs e)
        {
            txtNome.Focus();

            if (_edicao)
            {
                txtNome.SelectAll();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            LimparErro();

            string nome = txtNome.Text.Trim();

            if (nome.Length == 0)
            {
                MostrarErro("Informe o nome do produto.", txtNome);
                return;
            }

            if (!TentarLerPreco(txtPreco.Text, out decimal preco))
            {
                MostrarErro("Informe um preço válido. Use vírgula para os centavos (ex.: 29,90).", txtPreco);
                return;
            }

            if (!TentarLerQuantidade(txtQuantidade.Text, out int quantidade))
            {
                MostrarErro("Informe uma quantidade inteira igual ou maior que zero.", txtQuantidade);
                return;
            }

            _produto.Nome = nome;
            _produto.Preco = preco;
            _produto.Quantidade = quantidade;

            try
            {
                if (_produto.Id == 0)
                {
                    _repositorio.Inserir(_produto);
                }
                else
                {
                    _repositorio.Atualizar(_produto);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Tema.MostrarErro(
                    this,
                    "Não foi possível salvar",
                    "O produto não foi salvo. Verifique a conexão com o banco de dados.\n\nDetalhes: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtPreco_Leave(object sender, EventArgs e)
        {
            if (TentarLerPreco(txtPreco.Text, out decimal preco))
            {
                txtPreco.Text = preco.ToString("N2", CulturaBr);
            }
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

        private static bool TentarLerPreco(string texto, out decimal preco)
        {
            preco = 0m;

            string valor = texto.Trim();
            if (valor.Length == 0)
            {
                return false;
            }

            valor = valor.Replace("R$", string.Empty, StringComparison.OrdinalIgnoreCase).Trim();
            if (valor.Length == 0)
            {
                return false;
            }

            const NumberStyles estilos = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;

            bool leu = decimal.TryParse(valor, estilos, CulturaBr, out preco);

            // Aceita também o formato com ponto decimal ("10.50"), comum ao digitar
            // no teclado numérico, sem confundir com separador de milhar ("1.234").
            if (leu
                && !valor.Contains(',')
                && valor.IndexOf('.') >= 0
                && valor.IndexOf('.') == valor.LastIndexOf('.'))
            {
                string casasDecimais = valor[(valor.IndexOf('.') + 1)..];

                if (casasDecimais.Length is > 0 and <= 2
                    && decimal.TryParse(valor, estilos, CultureInfo.InvariantCulture, out decimal valorComPonto))
                {
                    preco = valorComPonto;
                }
            }

            if (!leu
                && decimal.TryParse(valor, estilos, CultureInfo.InvariantCulture, out decimal valorAlternativo))
            {
                preco = valorAlternativo;
                leu = true;
            }

            if (!leu || preco < 0)
            {
                return false;
            }

            preco = decimal.Round(preco, 2, MidpointRounding.AwayFromZero);
            return true;
        }

        private static bool TentarLerQuantidade(string texto, out int quantidade)
        {
            quantidade = 0;

            return int.TryParse(
                texto.Trim(),
                NumberStyles.Integer | NumberStyles.AllowThousands,
                CulturaBr,
                out quantidade)
                && quantidade >= 0;
        }
    }
}
