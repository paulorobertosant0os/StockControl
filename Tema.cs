using System.Runtime.InteropServices;

namespace StockControl
{
    internal static class Tema
    {
        public static readonly Color Fundo = Color.FromArgb(22, 27, 34);
        public static readonly Color Sidebar = Color.FromArgb(13, 17, 23);
        public static readonly Color Cartao = Color.FromArgb(28, 33, 40);
        public static readonly Color Borda = Color.FromArgb(48, 54, 61);
        public static readonly Color Texto = Color.FromArgb(230, 237, 243);
        public static readonly Color TextoSuave = Color.FromArgb(139, 148, 158);
        public static readonly Color Acento = Color.FromArgb(88, 166, 255);
        public static readonly Color Sucesso = Color.FromArgb(63, 185, 80);
        public static readonly Color Alerta = Color.FromArgb(248, 81, 73);
        public static readonly Color Hover = Color.FromArgb(33, 38, 45);

        public static readonly Color FundoCampo = Color.FromArgb(15, 20, 26);
        public static readonly Color AcentoClaro = Color.FromArgb(121, 192, 255);
        public static readonly Color AcentoEscuro = Color.FromArgb(56, 139, 253);
        public static readonly Color Aviso = Color.FromArgb(210, 153, 34);
        public static readonly Color LinhaAlternada = Color.FromArgb(24, 29, 36);

        public static Font Fonte(float tamanho, FontStyle estilo = FontStyle.Regular)
            => new("Segoe UI", tamanho, estilo, GraphicsUnit.Point);

        public static void PrepararFormulario(Form formulario)
        {
            formulario.BackColor = Fundo;
            formulario.ForeColor = Texto;
            formulario.Font = Fonte(9F);
            formulario.FormBorderStyle = FormBorderStyle.FixedDialog;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.MaximizeBox = false;
            formulario.MinimizeBox = false;
            formulario.ShowInTaskbar = false;

            AplicarTituloEscuro(formulario);
        }

        public static void EstilizarRotulo(Label rotulo)
        {
            rotulo.ForeColor = TextoSuave;
            rotulo.Font = Fonte(9F);
        }

        public static void EstilizarCampo(TextBoxBase campo)
        {
            campo.AutoSize = false;
            campo.BackColor = FundoCampo;
            campo.ForeColor = Texto;
            campo.BorderStyle = BorderStyle.FixedSingle;
            campo.Font = Fonte(10F);

            campo.Enter += (_, _) => campo.BackColor = Cartao;
            campo.Leave += (_, _) => campo.BackColor = FundoCampo;
        }

        public static void EstilizarCampo(NumericUpDown campo)
        {
            campo.BackColor = FundoCampo;
            campo.ForeColor = Texto;
            campo.BorderStyle = BorderStyle.FixedSingle;
            campo.Font = Fonte(10F);

            campo.Enter += (_, _) => campo.BackColor = Cartao;
            campo.Leave += (_, _) => campo.BackColor = FundoCampo;
        }

        public static void EstilizarBotaoPrimario(Button botao)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.FlatAppearance.BorderSize = 0;
            botao.FlatAppearance.MouseOverBackColor = AcentoClaro;
            botao.FlatAppearance.MouseDownBackColor = AcentoEscuro;
            botao.BackColor = Acento;
            botao.ForeColor = Sidebar;
            botao.Font = Fonte(9.5F, FontStyle.Bold);
            botao.Cursor = Cursors.Hand;
            botao.UseVisualStyleBackColor = false;
        }

        public static void EstilizarBotaoSecundario(Button botao)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.FlatAppearance.BorderSize = 1;
            botao.FlatAppearance.BorderColor = Borda;
            botao.FlatAppearance.MouseOverBackColor = Hover;
            botao.FlatAppearance.MouseDownBackColor = Fundo;
            botao.BackColor = Cartao;
            botao.ForeColor = Texto;
            botao.Font = Fonte(9.5F);
            botao.Cursor = Cursors.Hand;
            botao.UseVisualStyleBackColor = false;
        }

        public static void EstilizarBotaoPerigo(Button botao)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.FlatAppearance.BorderSize = 0;
            botao.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 110, 103);
            botao.FlatAppearance.MouseDownBackColor = Color.FromArgb(205, 55, 48);
            botao.BackColor = Alerta;
            botao.ForeColor = Color.White;
            botao.Font = Fonte(9.5F, FontStyle.Bold);
            botao.Cursor = Cursors.Hand;
            botao.UseVisualStyleBackColor = false;
        }

        public static void EstilizarBotaoMenu(Button botao)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.FlatAppearance.BorderSize = 0;
            botao.FlatAppearance.MouseOverBackColor = Hover;
            botao.FlatAppearance.MouseDownBackColor = Cartao;
            botao.BackColor = Sidebar;
            botao.ForeColor = Texto;
            botao.TextAlign = ContentAlignment.MiddleLeft;
            botao.Padding = new Padding(18, 0, 0, 0);
            botao.Font = Fonte(9.5F);
            botao.Cursor = Cursors.Hand;
            botao.UseVisualStyleBackColor = false;
        }

        public static void EstilizarGrade(DataGridView grade)
        {
            grade.BackgroundColor = Cartao;
            grade.GridColor = Borda;
            grade.BorderStyle = BorderStyle.None;
            grade.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grade.EnableHeadersVisualStyles = false;
            grade.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grade.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grade.ColumnHeadersHeight = 38;
            grade.RowTemplate.Height = 34;
            grade.RowHeadersVisible = false;
            grade.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grade.MultiSelect = false;
            grade.AllowUserToAddRows = false;
            grade.AllowUserToResizeRows = false;
            grade.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grade.ColumnHeadersDefaultCellStyle.BackColor = Cartao;
            grade.ColumnHeadersDefaultCellStyle.ForeColor = TextoSuave;
            grade.ColumnHeadersDefaultCellStyle.SelectionBackColor = Cartao;
            grade.ColumnHeadersDefaultCellStyle.SelectionForeColor = TextoSuave;
            grade.ColumnHeadersDefaultCellStyle.Font = Fonte(9F, FontStyle.Bold);
            grade.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 10, 0);

            grade.DefaultCellStyle.BackColor = Fundo;
            grade.DefaultCellStyle.ForeColor = Texto;
            grade.DefaultCellStyle.SelectionBackColor = Hover;
            grade.DefaultCellStyle.SelectionForeColor = Acento;
            grade.DefaultCellStyle.Font = Fonte(9.5F);
            grade.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);

            grade.AlternatingRowsDefaultCellStyle.BackColor = LinhaAlternada;
        }

        public static void MostrarInformacao(IWin32Window? proprietario, string titulo, string mensagem)
            => DialogoMensagem.Exibir(proprietario, titulo, mensagem, TipoMensagem.Informacao);

        public static void MostrarAviso(IWin32Window? proprietario, string titulo, string mensagem)
            => DialogoMensagem.Exibir(proprietario, titulo, mensagem, TipoMensagem.Aviso);

        public static void MostrarErro(IWin32Window? proprietario, string titulo, string mensagem)
            => DialogoMensagem.Exibir(proprietario, titulo, mensagem, TipoMensagem.Erro);

        public static bool Confirmar(
            IWin32Window? proprietario,
            string titulo,
            string mensagem,
            string textoConfirmar = "Confirmar",
            bool destrutivo = false)
            => DialogoMensagem.Confirmar(proprietario, titulo, mensagem, textoConfirmar, destrutivo) == DialogResult.OK;

        public static void AplicarTituloEscuro(Form formulario)
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            void Aplicar()
            {
                try
                {
                    if (!formulario.IsHandleCreated)
                    {
                        return;
                    }

                    int ativo = 1;

                    // Windows 11 / 10 recentes usam o atributo 20; versões antigas usam o 19.
                    if (DwmSetWindowAttribute(formulario.Handle, 20, ref ativo, sizeof(int)) != 0)
                    {
                        DwmSetWindowAttribute(formulario.Handle, 19, ref ativo, sizeof(int));
                    }
                }
                catch (DllNotFoundException)
                {
                }
                catch (EntryPointNotFoundException)
                {
                }
            }

            if (formulario.IsHandleCreated)
            {
                Aplicar();
            }
            else
            {
                formulario.HandleCreated += (_, _) => Aplicar();
            }

            // Alguns formulários só recebem a barra de título definitiva depois
            // de exibidos; reaplicar em Load/Shown garante o tema escuro.
            formulario.Load += (_, _) => Aplicar();
            formulario.Shown += (_, _) => Aplicar();
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr janela, int atributo, ref int valor, int tamanho);
    }
}
