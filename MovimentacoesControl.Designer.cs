namespace StockControl
{
    partial class MovimentacoesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblProduto = new Label();
            cboProduto = new ComboBoxEscuro();
            lblTipo = new Label();
            cboTipo = new ComboBoxEscuro();
            lblQuantidade = new Label();
            numQuantidade = new NumericUpDownEscuro();
            lblObservacao = new Label();
            txtObservacao = new TextBox();
            btnRegistrar = new Button();
            gridMovimentacoes = new DataGridView();
            lblRodape = new Label();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridMovimentacoes).BeginInit();
            SuspendLayout();
            // 
            // lblProduto
            // 
            lblProduto.AutoSize = true;
            lblProduto.Location = new Point(0, 0);
            lblProduto.Name = "lblProduto";
            lblProduto.Size = new Size(50, 15);
            lblProduto.TabIndex = 0;
            lblProduto.Text = "Produto";
            // 
            // cboProduto
            // 
            cboProduto.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProduto.FormattingEnabled = true;
            cboProduto.Location = new Point(0, 22);
            cboProduto.Name = "cboProduto";
            cboProduto.Size = new Size(250, 28);
            cboProduto.TabIndex = 1;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(258, 0);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(31, 15);
            lblTipo.TabIndex = 2;
            lblTipo.Text = "Tipo";
            // 
            // cboTipo
            // 
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(258, 22);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(140, 28);
            cboTipo.TabIndex = 3;
            // 
            // lblQuantidade
            // 
            lblQuantidade.AutoSize = true;
            lblQuantidade.Location = new Point(406, 0);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new Size(69, 15);
            lblQuantidade.TabIndex = 4;
            lblQuantidade.Text = "Quantidade";
            // 
            // numQuantidade
            // 
            numQuantidade.Location = new Point(406, 22);
            numQuantidade.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numQuantidade.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantidade.Name = "numQuantidade";
            numQuantidade.Size = new Size(110, 28);
            numQuantidade.TabIndex = 5;
            numQuantidade.TextAlign = HorizontalAlignment.Right;
            numQuantidade.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblObservacao
            // 
            lblObservacao.AutoSize = true;
            lblObservacao.Location = new Point(0, 62);
            lblObservacao.Name = "lblObservacao";
            lblObservacao.Size = new Size(69, 15);
            lblObservacao.TabIndex = 6;
            lblObservacao.Text = "Observação";
            // 
            // txtObservacao
            // 
            txtObservacao.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtObservacao.Location = new Point(0, 84);
            txtObservacao.Name = "txtObservacao";
            txtObservacao.Size = new Size(566, 25);
            txtObservacao.TabIndex = 7;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRegistrar.Location = new Point(580, 84);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(210, 28);
            btnRegistrar.TabIndex = 8;
            btnRegistrar.Text = "Registrar movimentação";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // gridMovimentacoes
            // 
            gridMovimentacoes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridMovimentacoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridMovimentacoes.Location = new Point(0, 130);
            gridMovimentacoes.Name = "gridMovimentacoes";
            gridMovimentacoes.Size = new Size(790, 430);
            gridMovimentacoes.TabIndex = 9;
            // 
            // lblRodape
            // 
            lblRodape.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblRodape.AutoSize = true;
            lblRodape.Location = new Point(0, 566);
            lblRodape.Name = "lblRodape";
            lblRodape.Size = new Size(123, 15);
            lblRodape.TabIndex = 10;
            lblRodape.Text = "0 movimentação(ões)";
            // 
            // MovimentacoesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblRodape);
            Controls.Add(gridMovimentacoes);
            Controls.Add(btnRegistrar);
            Controls.Add(txtObservacao);
            Controls.Add(lblObservacao);
            Controls.Add(numQuantidade);
            Controls.Add(lblQuantidade);
            Controls.Add(cboTipo);
            Controls.Add(lblTipo);
            Controls.Add(cboProduto);
            Controls.Add(lblProduto);
            Name = "MovimentacoesControl";
            Size = new Size(790, 590);
            ((System.ComponentModel.ISupportInitialize)numQuantidade).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridMovimentacoes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProduto;
        private ComboBoxEscuro cboProduto;
        private Label lblTipo;
        private ComboBoxEscuro cboTipo;
        private Label lblQuantidade;
        private NumericUpDownEscuro numQuantidade;
        private Label lblObservacao;
        private TextBox txtObservacao;
        private Button btnRegistrar;
        private DataGridView gridMovimentacoes;
        private Label lblRodape;
    }
}
