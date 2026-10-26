using Microsoft.Data.SqlClient;
using StockControl.Data;
using StockControl.Models;
using System.Drawing.Text;
using System.Globalization;

namespace StockControl
{
    public partial class Form1 : Form
    {
        private readonly ProdutosControl _produtosControl = new();
        private readonly MovimentacoesControl _movimentacoesControl = new();
        private readonly EstoqueControl _estoqueControl = new();
        private readonly DashboardControl _dashboardControl = new();
        private Button? _botaoAtivo;

        public Form1()
        {
            InitializeComponent();

            Tema.AplicarTituloEscuro(this);

            BackColor = Tema.Fundo;
            panelMenu.BackColor = Tema.Sidebar;
            panelConteudo.BackColor = Tema.Fundo;
            panelTela.BackColor = Tema.Fundo;

            lblLogo.ForeColor = Tema.Texto;
            lblLogo.Font = Tema.Fonte(13F, FontStyle.Bold);

            lblSubtituloMenu.ForeColor = Tema.TextoSuave;
            lblSubtituloMenu.Font = Tema.Fonte(8.5F);

            panelSeparador.BackColor = Tema.Borda;

            lblTitulo.ForeColor = Tema.Texto;
            lblTitulo.Font = Tema.Fonte(15F, FontStyle.Bold);

            lblPlaceholder.ForeColor = Tema.TextoSuave;

            foreach (var botao in BotoesMenu())
            {
                Tema.EstilizarBotaoMenu(botao);
                botao.Click += (s, e) => Navegar((Button)s!);
            }

            _produtosControl.Dock = DockStyle.Fill;
            panelTela.Controls.Add(_produtosControl);

            _movimentacoesControl.Dock = DockStyle.Fill;
            panelTela.Controls.Add(_movimentacoesControl);

            _estoqueControl.Dock = DockStyle.Fill;
            panelTela.Controls.Add(_estoqueControl);

            _dashboardControl.Dock = DockStyle.Fill;
            panelTela.Controls.Add(_dashboardControl);
            lblPlaceholder.Visible = false;

            Navegar(btnDashboard);

        }

        private void Navegar(Button botao)
        {
            Destacar(botao);

            bool dashboard = botao == btnDashboard;
            bool produtos = botao == btnProdutos;
            bool estoque = botao == btnEstoque;
            bool movimentacoes = botao == btnMovimentacoes;

            _dashboardControl.Visible = dashboard;
            _produtosControl.Visible = produtos;
            _estoqueControl.Visible = estoque;
            _movimentacoesControl.Visible = movimentacoes;

            if (dashboard)
            {
                MostrarTitulo("Visão geral");
                _dashboardControl.Recarregar();
            }
            else if (produtos)
            {
                MostrarTitulo("Produtos");
                _produtosControl.Recarregar();
            }
            else if (estoque)
            {
                MostrarTitulo("Estoque");
                _estoqueControl.Recarregar();
            }
            else
            {
                MostrarTitulo("Movimentações");
                _movimentacoesControl.Recarregar();
            }
        }

        private void Destacar(Button ativo)
        {
            _botaoAtivo = ativo;

            foreach (var botao in BotoesMenu())
            {
                bool selecionado = botao == _botaoAtivo;

                botao.BackColor = selecionado ? Tema.Hover : Tema.Sidebar;
                botao.ForeColor = selecionado ? Tema.Acento : Tema.Texto;

            }
        }

        private void MostrarTitulo(string titulo) => lblTitulo.Text = titulo;

        private Button[] BotoesMenu() => new[] { btnDashboard, btnProdutos, btnEstoque, btnMovimentacoes };

    }
}
