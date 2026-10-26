namespace StockControl
{
    /// <summary>
    /// NumericUpDown com o campo e os botões de incremento no tema escuro.
    /// O controle nativo desenha os botões em branco, então eles são cobertos
    /// por um painel próprio que mantém o incremento/decremento funcionando.
    /// </summary>
    internal sealed class NumericUpDownEscuro : NumericUpDown
    {
        private const int LarguraBotoes = 18;

        private Panel _botoes = null!;
        private int _areaHover = -1;

        public NumericUpDownEscuro()
        {
            AutoSize = false;
            BackColor = Tema.FundoCampo;
            ForeColor = Tema.Texto;
            BorderStyle = BorderStyle.FixedSingle;
            Font = Tema.Fonte(10F);
            TextAlign = HorizontalAlignment.Right;

            _botoes = new Panel
            {
                BackColor = Tema.FundoCampo,
                Cursor = Cursors.Hand,
                TabStop = false
            };

            _botoes.Paint += Botoes_Paint;
            _botoes.MouseMove += Botoes_MouseMove;
            _botoes.MouseLeave += (_, _) => DefinirHover(-1);
            _botoes.MouseDown += Botoes_MouseDown;
            _botoes.MouseWheel += Botoes_MouseWheel;

            Controls.Add(_botoes);
            _botoes.BringToFront();

            AjustarBotoes();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AjustarBotoes();
            BeginInvoke(new Action(TrazerBotoesParaFrente));
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AjustarBotoes();
        }

        private void TrazerBotoesParaFrente()
        {
            if (_botoes is null || !_botoes.IsHandleCreated)
            {
                return;
            }

            // Os botões nativos do NumericUpDown têm handle próprio e, ao serem
            // criados, sobem para o topo da ordem Z e cobrem o nosso painel.
            SetWindowPos(_botoes.Handle, IntPtr.Zero, 0, 0, 0, 0, SwpNoMove | SwpNoSize | SwpNoActivate);
        }

        private const int SwpNoSize = 0x0001;
        private const int SwpNoMove = 0x0002;
        private const int SwpNoActivate = 0x0010;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetWindowPos(
            IntPtr janela,
            IntPtr inserirDepois,
            int x,
            int y,
            int largura,
            int altura,
            int flags);

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            BackColor = Tema.Cartao;
            _botoes.BackColor = Tema.Cartao;
            _botoes.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            BackColor = Tema.FundoCampo;
            _botoes.BackColor = Tema.FundoCampo;
            _botoes.Invalidate();
        }

        private void AjustarBotoes()
        {
            if (_botoes is null)
            {
                return;
            }

            // Os botões nativos são a referência ideal: assim o painel cobre
            // exatamente a mesma área em qualquer escala de DPI.
            var nativos = BotoesNativos();

            if (nativos is not null && nativos.Width > 0 && nativos.Height > 0)
            {
                _botoes.Bounds = nativos.Bounds;
                return;
            }

            int largura = Math.Max(
                LarguraBotoes,
                (int)Math.Round(LarguraBotoes * DeviceDpi / 96.0));

            _botoes.Bounds = new Rectangle(Width - largura - 1, 1, largura, Math.Max(0, Height - 2));
        }

        private Control? BotoesNativos()
        {
            foreach (Control filho in Controls)
            {
                if (filho.GetType().Name == "UpDownButtons")
                {
                    return filho;
                }
            }

            return null;
        }

        private void Botoes_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            if (e.Y < _botoes.Height / 2)
            {
                UpButton();
            }
            else
            {
                DownButton();
            }
        }

        private void Botoes_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                UpButton();
            }
            else
            {
                DownButton();
            }
        }

        private void Botoes_MouseMove(object? sender, MouseEventArgs e)
        {
            DefinirHover(e.Y < _botoes.Height / 2 ? 0 : 1);
        }

        private void DefinirHover(int area)
        {
            if (_areaHover == area)
            {
                return;
            }

            _areaHover = area;
            _botoes.Invalidate();
        }

        private void Botoes_Paint(object? sender, PaintEventArgs e)
        {
            var grafico = e.Graphics;
            int meio = _botoes.Height / 2;

            using (var fundo = new SolidBrush(_botoes.BackColor))
            {
                grafico.FillRectangle(fundo, _botoes.ClientRectangle);
            }

            if (_areaHover >= 0)
            {
                var area = _areaHover == 0
                    ? new Rectangle(0, 0, _botoes.Width, meio)
                    : new Rectangle(0, meio, _botoes.Width, _botoes.Height - meio);

                using var fundoHover = new SolidBrush(Tema.Hover);
                grafico.FillRectangle(fundoHover, area);
            }

            using (var caneta = new Pen(Tema.Borda))
            {
                grafico.DrawLine(caneta, 0, 3, 0, _botoes.Height - 4);
                grafico.DrawLine(caneta, 1, meio, _botoes.Width - 1, meio);
            }

            int centroX = _botoes.Width / 2;
            int centroY = meio;

            using var pincel = new SolidBrush(Tema.TextoSuave);

            var setaCima = new[]
            {
                new Point(centroX - 4, centroY - 5),
                new Point(centroX + 4, centroY - 5),
                new Point(centroX, centroY - 9)
            };

            var setaBaixo = new[]
            {
                new Point(centroX - 4, centroY + 5),
                new Point(centroX + 4, centroY + 5),
                new Point(centroX, centroY + 9)
            };

            grafico.FillPolygon(pincel, setaCima);
            grafico.FillPolygon(pincel, setaBaixo);
        }
    }
}
