namespace StockControl
{
    /// <summary>
    /// ComboBox com o visual escuro do restante do sistema.
    /// O WinForms desenha o botÃ£o nativo da seta com as cores do Windows,
    /// por isso a Ã¡rea Ã© repintada para manter a identidade visual.
    /// </summary>
    internal sealed class ComboBoxEscuro : ComboBox
    {
        private const int WM_PAINT = 0x000F;
        private const int LarguraBotao = 26;

        public ComboBoxEscuro()
        {
            FlatStyle = FlatStyle.Flat;
            BackColor = Tema.FundoCampo;
            ForeColor = Tema.Texto;
            Font = Tema.Fonte(10F);
            IntegralHeight = false;
            DropDownHeight = 240;
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 19;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            bool selecionado = (e.State & DrawItemState.Selected) != 0;

            using (var fundo = new SolidBrush(selecionado ? Tema.Hover : Tema.FundoCampo))
            {
                e.Graphics.FillRectangle(fundo, e.Bounds);
            }

            if (e.Index < 0)
            {
                return;
            }

            string texto = GetItemText(Items[e.Index]) ?? string.Empty;
            var area = new Rectangle(e.Bounds.X + 8, e.Bounds.Y, e.Bounds.Width - 8, e.Bounds.Height);

            TextRenderer.DrawText(
                e.Graphics,
                texto,
                Font,
                area,
                selecionado ? Tema.Acento : Tema.Texto,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            BackColor = Tema.Cartao;
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            BackColor = Tema.FundoCampo;
            Invalidate();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg != WM_PAINT || !IsHandleCreated)
            {
                return;
            }

            using var grafico = Graphics.FromHwnd(Handle);

            var areaBotao = new Rectangle(Width - LarguraBotao - 1, 1, LarguraBotao, Height - 2);

            using (var fundo = new SolidBrush(BackColor))
            {
                grafico.FillRectangle(fundo, areaBotao);
            }

            using (var caneta = new Pen(Tema.Borda))
            {
                grafico.DrawLine(caneta, Width - LarguraBotao, 4, Width - LarguraBotao, Height - 5);
            }

            int centroX = Width - (LarguraBotao / 2) - 1;
            int centroY = Height / 2;

            using (var caneta = new Pen(Tema.TextoSuave, 1.4F))
            {
                grafico.DrawLine(caneta, centroX - 4, centroY - 2, centroX, centroY + 2);
                grafico.DrawLine(caneta, centroX, centroY + 2, centroX + 4, centroY - 2);
            }

            using (var caneta = new Pen(Focused ? Tema.Acento : Tema.Borda))
            {
                grafico.DrawRectangle(caneta, 0, 0, Width - 1, Height - 1);
            }
        }
    }
}
