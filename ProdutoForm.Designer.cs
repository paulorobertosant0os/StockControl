namespace StockControl
{
    partial class ProdutoForm
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
            txtNome = new TextBox();
            label2 = new Label();
            txtPreco = new TextBox();
            labelquantidade = new Label();
            txtQuantidade = new TextBox();
            lblAjudaPreco = new Label();
            lblAjudaQuantidade = new Label();
            lblErro = new Label();
            panelLinhaRodape = new Panel();
            panelRodape = new Panel();
            btnCancelar = new Button();
            btnSalvar = new Button();
            panelCabecalho.SuspendLayout();
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
            panelCabecalho.Size = new Size(520, 96);
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
            lblTitulo.Size = new Size(111, 30);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Novo produto";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Location = new Point(46, 55);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(214, 15);
            lblSubtitulo.TabIndex = 2;
            lblSubtitulo.Text = "Cadastre um novo item no seu estoque.";
            // 
            // panelLinhaCabecalho
            // 
            panelLinhaCabecalho.Location = new Point(0, 96);
            panelLinhaCabecalho.Name = "panelLinhaCabecalho";
            panelLinhaCabecalho.Size = new Size(520, 1);
            panelLinhaCabecalho.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 116);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 2;
            label1.Text = "Nome";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(28, 136);
            txtNome.MaxLength = 150;
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Ex.: Teclado mecânico";
            txtNome.Size = new Size(464, 25);
            txtNome.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 182);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 4;
            label2.Text = "Preço (R$)";
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(28, 202);
            txtPreco.MaxLength = 18;
            txtPreco.Name = "txtPreco";
            txtPreco.PlaceholderText = "0,00";
            txtPreco.Size = new Size(220, 25);
            txtPreco.TabIndex = 5;
            txtPreco.TextAlign = HorizontalAlignment.Right;
            txtPreco.Leave += txtPreco_Leave;
            // 
            // labelquantidade
            // 
            labelquantidade.AutoSize = true;
            labelquantidade.Location = new Point(272, 182);
            labelquantidade.Name = "labelquantidade";
            labelquantidade.Size = new Size(69, 15);
            labelquantidade.TabIndex = 6;
            labelquantidade.Text = "Quantidade";
            // 
            // txtQuantidade
            // 
            txtQuantidade.Location = new Point(272, 202);
            txtQuantidade.MaxLength = 9;
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.PlaceholderText = "0";
            txtQuantidade.Size = new Size(220, 25);
            txtQuantidade.TabIndex = 7;
            txtQuantidade.TextAlign = HorizontalAlignment.Right;
            // 
            // lblAjudaPreco
            // 
            lblAjudaPreco.AutoSize = true;
            lblAjudaPreco.Location = new Point(28, 236);
            lblAjudaPreco.Name = "lblAjudaPreco";
            lblAjudaPreco.Size = new Size(178, 15);
            lblAjudaPreco.TabIndex = 8;
            lblAjudaPreco.Text = "Use vírgula para os centavos";
            // 
            // lblAjudaQuantidade
            // 
            lblAjudaQuantidade.AutoSize = true;
            lblAjudaQuantidade.Location = new Point(272, 236);
            lblAjudaQuantidade.Name = "lblAjudaQuantidade";
            lblAjudaQuantidade.Size = new Size(123, 15);
            lblAjudaQuantidade.TabIndex = 9;
            lblAjudaQuantidade.Text = "Unidades em estoque";
            // 
            // lblErro
            // 
            lblErro.Location = new Point(28, 258);
            lblErro.Name = "lblErro";
            lblErro.Size = new Size(464, 30);
            lblErro.TabIndex = 10;
            lblErro.Visible = false;
            // 
            // panelLinhaRodape
            // 
            panelLinhaRodape.Location = new Point(0, 292);
            panelLinhaRodape.Name = "panelLinhaRodape";
            panelLinhaRodape.Size = new Size(520, 1);
            panelLinhaRodape.TabIndex = 11;
            // 
            // panelRodape
            // 
            panelRodape.Controls.Add(btnCancelar);
            panelRodape.Controls.Add(btnSalvar);
            panelRodape.Location = new Point(0, 293);
            panelRodape.Name = "panelRodape";
            panelRodape.Size = new Size(520, 97);
            panelRodape.TabIndex = 12;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(224, 29);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(116, 40);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(352, 29);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(140, 40);
            btnSalvar.TabIndex = 1;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // ProdutoForm
            // 
            AcceptButton = btnSalvar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(520, 390);
            Controls.Add(panelRodape);
            Controls.Add(panelLinhaRodape);
            Controls.Add(lblErro);
            Controls.Add(lblAjudaQuantidade);
            Controls.Add(lblAjudaPreco);
            Controls.Add(txtQuantidade);
            Controls.Add(labelquantidade);
            Controls.Add(txtPreco);
            Controls.Add(label2);
            Controls.Add(txtNome);
            Controls.Add(label1);
            Controls.Add(panelLinhaCabecalho);
            Controls.Add(panelCabecalho);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProdutoForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Novo produto";
            Load += ProdutoForm_Load;
            panelCabecalho.ResumeLayout(false);
            panelCabecalho.PerformLayout();
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
        private TextBox txtNome;
        private Label label2;
        private TextBox txtPreco;
        private Label labelquantidade;
        private TextBox txtQuantidade;
        private Label lblAjudaPreco;
        private Label lblAjudaQuantidade;
        private Label lblErro;
        private Panel panelLinhaRodape;
        private Panel panelRodape;
        private Button btnCancelar;
        private Button btnSalvar;
    }
}
