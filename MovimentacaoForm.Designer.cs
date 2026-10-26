namespace StockControl
{
    partial class MovimentacaoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelCabecalho = new Panel();
            panelAcento = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            panelLinhaCabecalho = new Panel();
            label1 = new Label();
            cmbProduto = new ComboBoxEscuro();
            lblSaldo = new Label();
            label2 = new Label();
            panelEntrada = new Panel();
            rbEntrada = new RadioButton();
            lblEntradaDescricao = new Label();
            panelSaida = new Panel();
            rbSaida = new RadioButton();
            lblSaidaDescricao = new Label();
            label3 = new Label();
            txtQuantidade = new TextBox();
            label4 = new Label();
            txtObservacao = new TextBox();
            lblErro = new Label();
            panelLinhaRodape = new Panel();
            panelRodape = new Panel();
            btnCancelar = new Button();
            btnSalvar = new Button();
            panelCabecalho.SuspendLayout();
            panelEntrada.SuspendLayout();
            panelSaida.SuspendLayout();
            panelRodape.SuspendLayout();
            SuspendLayout();
            // 
            // panelCabecalho
            // 
            panelCabecalho.Controls.Add(panelAcento);
            panelCabecalho.Controls.Add(lblTitulo);
            panelCabecalho.Controls.Add(lblSubtitulo);
            panelCabecalho.Location = new Point(0, 0);
            panelCabecalho.Name = "panelCabecalho";
            panelCabecalho.Size = new Size(560, 96);
            panelCabecalho.TabIndex = 0;
            // 
            // panelAcento
            // 
            panelAcento.Location = new Point(28, 30);
            panelAcento.Name = "panelAcento";
            panelAcento.Size = new Size(4, 34);
            panelAcento.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(44, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(161, 30);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Movimentar estoque";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Location = new Point(46, 55);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(252, 15);
            lblSubtitulo.TabIndex = 2;
            lblSubtitulo.Text = "Registre uma entrada ou saída de produtos.";
            // 
            // panelLinhaCabecalho
            // 
            panelLinhaCabecalho.Location = new Point(0, 96);
            panelLinhaCabecalho.Name = "panelLinhaCabecalho";
            panelLinhaCabecalho.Size = new Size(560, 1);
            panelLinhaCabecalho.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 116);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 2;
            label1.Text = "Produto";
            // 
            // cmbProduto
            // 
            cmbProduto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduto.FormattingEnabled = true;
            cmbProduto.Location = new Point(28, 136);
            cmbProduto.Name = "cmbProduto";
            cmbProduto.Size = new Size(504, 30);
            cmbProduto.TabIndex = 3;
            cmbProduto.SelectedIndexChanged += cmbProduto_SelectedIndexChanged;
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Location = new Point(28, 170);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(196, 15);
            lblSaldo.TabIndex = 4;
            lblSaldo.Text = "Estoque atual: —";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 200);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 5;
            label2.Text = "Tipo de movimentação";
            // 
            // panelEntrada
            // 
            panelEntrada.Controls.Add(rbEntrada);
            panelEntrada.Controls.Add(lblEntradaDescricao);
            panelEntrada.Location = new Point(28, 220);
            panelEntrada.Name = "panelEntrada";
            panelEntrada.Size = new Size(244, 66);
            panelEntrada.TabIndex = 6;
            // 
            // rbEntrada
            // 
            rbEntrada.AutoSize = true;
            rbEntrada.Checked = true;
            rbEntrada.Location = new Point(14, 10);
            rbEntrada.Name = "rbEntrada";
            rbEntrada.Size = new Size(65, 19);
            rbEntrada.TabIndex = 0;
            rbEntrada.TabStop = true;
            rbEntrada.Text = "Entrada";
            rbEntrada.UseVisualStyleBackColor = false;
            rbEntrada.CheckedChanged += rbTipo_CheckedChanged;
            // 
            // lblEntradaDescricao
            // 
            lblEntradaDescricao.AutoSize = true;
            lblEntradaDescricao.Location = new Point(32, 34);
            lblEntradaDescricao.Name = "lblEntradaDescricao";
            lblEntradaDescricao.Size = new Size(172, 15);
            lblEntradaDescricao.TabIndex = 1;
            lblEntradaDescricao.Text = "Adiciona unidades ao estoque";
            // 
            // panelSaida
            // 
            panelSaida.Controls.Add(rbSaida);
            panelSaida.Controls.Add(lblSaidaDescricao);
            panelSaida.Location = new Point(288, 220);
            panelSaida.Name = "panelSaida";
            panelSaida.Size = new Size(244, 66);
            panelSaida.TabIndex = 7;
            // 
            // rbSaida
            // 
            rbSaida.AutoSize = true;
            rbSaida.Location = new Point(14, 10);
            rbSaida.Name = "rbSaida";
            rbSaida.Size = new Size(53, 19);
            rbSaida.TabIndex = 0;
            rbSaida.Text = "Saída";
            rbSaida.UseVisualStyleBackColor = false;
            rbSaida.CheckedChanged += rbTipo_CheckedChanged;
            // 
            // lblSaidaDescricao
            // 
            lblSaidaDescricao.AutoSize = true;
            lblSaidaDescricao.Location = new Point(32, 34);
            lblSaidaDescricao.Name = "lblSaidaDescricao";
            lblSaidaDescricao.Size = new Size(161, 15);
            lblSaidaDescricao.TabIndex = 1;
            lblSaidaDescricao.Text = "Retira unidades do estoque";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 304);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 8;
            label3.Text = "Quantidade";
            // 
            // txtQuantidade
            // 
            txtQuantidade.Location = new Point(28, 324);
            txtQuantidade.MaxLength = 9;
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.PlaceholderText = "0";
            txtQuantidade.Size = new Size(150, 25);
            txtQuantidade.TabIndex = 9;
            txtQuantidade.TextAlign = HorizontalAlignment.Right;
            txtQuantidade.TextChanged += txtQuantidade_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(198, 304);
            label4.Name = "label4";
            label4.Size = new Size(123, 15);
            label4.TabIndex = 10;
            label4.Text = "Observação (opcional)";
            // 
            // txtObservacao
            // 
            txtObservacao.Location = new Point(198, 324);
            txtObservacao.MaxLength = 200;
            txtObservacao.Name = "txtObservacao";
            txtObservacao.PlaceholderText = "Ex.: Compra do fornecedor";
            txtObservacao.Size = new Size(334, 25);
            txtObservacao.TabIndex = 11;
            // 
            // lblErro
            // 
            lblErro.Location = new Point(28, 358);
            lblErro.Name = "lblErro";
            lblErro.Size = new Size(504, 30);
            lblErro.TabIndex = 12;
            lblErro.Visible = false;
            // 
            // panelLinhaRodape
            // 
            panelLinhaRodape.Location = new Point(0, 389);
            panelLinhaRodape.Name = "panelLinhaRodape";
            panelLinhaRodape.Size = new Size(560, 1);
            panelLinhaRodape.TabIndex = 13;
            // 
            // panelRodape
            // 
            panelRodape.Controls.Add(btnCancelar);
            panelRodape.Controls.Add(btnSalvar);
            panelRodape.Location = new Point(0, 390);
            panelRodape.Name = "panelRodape";
            panelRodape.Size = new Size(560, 80);
            panelRodape.TabIndex = 14;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(214, 20);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(116, 40);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(342, 20);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(190, 40);
            btnSalvar.TabIndex = 1;
            btnSalvar.Text = "Confirmar movimentação";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // MovimentacaoForm
            // 
            AcceptButton = btnSalvar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(560, 470);
            Controls.Add(panelRodape);
            Controls.Add(panelLinhaRodape);
            Controls.Add(lblErro);
            Controls.Add(txtObservacao);
            Controls.Add(label4);
            Controls.Add(txtQuantidade);
            Controls.Add(label3);
            Controls.Add(panelSaida);
            Controls.Add(panelEntrada);
            Controls.Add(label2);
            Controls.Add(lblSaldo);
            Controls.Add(cmbProduto);
            Controls.Add(label1);
            Controls.Add(panelLinhaCabecalho);
            Controls.Add(panelCabecalho);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MovimentacaoForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Movimentar estoque";
            panelCabecalho.ResumeLayout(false);
            panelCabecalho.PerformLayout();
            panelEntrada.ResumeLayout(false);
            panelEntrada.PerformLayout();
            panelSaida.ResumeLayout(false);
            panelSaida.PerformLayout();
            panelRodape.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelCabecalho;
        private Panel panelAcento;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Panel panelLinhaCabecalho;
        private Label label1;
        private ComboBoxEscuro cmbProduto;
        private Label lblSaldo;
        private Label label2;
        private Panel panelEntrada;
        private RadioButton rbEntrada;
        private Label lblEntradaDescricao;
        private Panel panelSaida;
        private RadioButton rbSaida;
        private Label lblSaidaDescricao;
        private Label label3;
        private TextBox txtQuantidade;
        private Label label4;
        private TextBox txtObservacao;
        private Label lblErro;
        private Panel panelLinhaRodape;
        private Panel panelRodape;
        private Button btnCancelar;
        private Button btnSalvar;
    }
}
