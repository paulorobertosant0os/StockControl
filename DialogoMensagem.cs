namespace StockControl
{
    internal enum TipoMensagem
    {
        Informacao,
        Aviso,
        Erro
    }

    internal sealed class DialogoMensagem : Form
    {
        private const int LarguraFormulario = 460;
        private const int MargemConteudo = 28;
        private const int LarguraConteudo = 404;
        private const int AlturaRodape = 76;

        private DialogoMensagem(
            string titulo,
            string mensagem,
            TipoMensagem tipo,
            bool confirmacao,
            string textoConfirmar,
            bool destrutivo)
        {
            Tema.PrepararFormulario(this);

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            Text = titulo;
            ShowIcon = false;
            ClientSize = new Size(LarguraFormulario, 220);

            var corDestaque = tipo switch
            {
                TipoMensagem.Erro => Tema.Alerta,
                TipoMensagem.Aviso => Tema.Aviso,
                _ => confirmacao && destrutivo ? Tema.Alerta : Tema.Acento
            };

            var faixa = new Panel
            {
                Dock = DockStyle.Top,
                Height = 3,
                BackColor = corDestaque
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                AutoSize = false,
                Location = new Point(MargemConteudo, 26),
                Size = new Size(LarguraConteudo, 28),
                Font = Tema.Fonte(14F, FontStyle.Bold),
                ForeColor = Tema.Texto,
                BackColor = Color.Transparent
            };

            var fonteMensagem = Tema.Fonte(9.5F);
            int alturaTexto = TextRenderer.MeasureText(
                mensagem,
                fonteMensagem,
                new Size(LarguraConteudo, 1000),
                TextFormatFlags.WordBreak | TextFormatFlags.NoPadding | TextFormatFlags.TextBoxControl).Height;

            alturaTexto = Math.Clamp(alturaTexto, 40, 300);

            var lblMensagem = new Label
            {
                Text = mensagem,
                AutoSize = false,
                Location = new Point(MargemConteudo, 66),
                Size = new Size(LarguraConteudo, alturaTexto),
                Font = fonteMensagem,
                ForeColor = Tema.TextoSuave,
                BackColor = Color.Transparent
            };

            int alturaFormulario = Math.Max(220, 66 + alturaTexto + 24 + AlturaRodape);
            ClientSize = new Size(LarguraFormulario, alturaFormulario);

            int topoRodape = alturaFormulario - AlturaRodape;

            var linhaRodape = new Panel
            {
                Location = new Point(0, topoRodape - 1),
                Size = new Size(LarguraFormulario, 1),
                BackColor = Tema.Borda,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            var rodape = new Panel
            {
                Location = new Point(0, topoRodape),
                Size = new Size(LarguraFormulario, AlturaRodape),
                BackColor = Tema.Sidebar,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            var botoes = new FlowLayoutPanel
            {
                Location = new Point(MargemConteudo, 18),
                Size = new Size(LarguraConteudo, 40),
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                BackColor = Tema.Sidebar
            };

            var textoBotao = confirmacao ? textoConfirmar : "Entendi";

            int larguraBotao = Math.Max(
                confirmacao ? 126 : 104,
                TextRenderer.MeasureText(textoBotao, Tema.Fonte(9.5F, FontStyle.Bold)).Width + 34);

            var btnConfirmar = new Button
            {
                Text = textoBotao,
                Size = new Size(larguraBotao, 40),
                DialogResult = DialogResult.OK
            };

            if (confirmacao && destrutivo)
            {
                Tema.EstilizarBotaoPerigo(btnConfirmar);
            }
            else
            {
                Tema.EstilizarBotaoPrimario(btnConfirmar);
            }

            botoes.Controls.Add(btnConfirmar);

            if (confirmacao)
            {
                var btnCancelar = new Button
                {
                    Text = "Cancelar",
                    Size = new Size(108, 40),
                    DialogResult = DialogResult.Cancel,
                    Margin = new Padding(8, 0, 0, 0)
                };

                Tema.EstilizarBotaoSecundario(btnCancelar);
                botoes.Controls.Add(btnCancelar);
                CancelButton = btnCancelar;
            }

            rodape.Controls.Add(botoes);

            AcceptButton = btnConfirmar;

            Controls.Add(linhaRodape);
            Controls.Add(rodape);
            Controls.Add(lblMensagem);
            Controls.Add(lblTitulo);
            Controls.Add(faixa);
        }

        public static void Exibir(
            IWin32Window? proprietario,
            string titulo,
            string mensagem,
            TipoMensagem tipo)
        {
            using var dialogo = new DialogoMensagem(titulo, mensagem, tipo, false, string.Empty, false);
            ExibirComProprietario(dialogo, proprietario);
        }

        public static DialogResult Confirmar(
            IWin32Window? proprietario,
            string titulo,
            string mensagem,
            string textoConfirmar,
            bool destrutivo)
        {
            using var dialogo = new DialogoMensagem(
                titulo,
                mensagem,
                TipoMensagem.Informacao,
                true,
                textoConfirmar,
                destrutivo);

            return ExibirComProprietario(dialogo, proprietario);
        }

        private static DialogResult ExibirComProprietario(Form dialogo, IWin32Window? proprietario)
            => proprietario is null ? dialogo.ShowDialog() : dialogo.ShowDialog(proprietario);
    }
}
