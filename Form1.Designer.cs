namespace StockControl
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMenu = new Panel();
            btnMovimentacoes = new Button();
            btnEstoque = new Button();
            btnProdutos = new Button();
            btnDashboard = new Button();
            panelSeparador = new Panel();
            lblSubtituloMenu = new Label();
            lblLogo = new Label();
            panelConteudo = new Panel();
            panelTela = new Panel();
            lblPlaceholder = new Label();
            lblTitulo = new Label();
            panelMenu.SuspendLayout();
            panelConteudo.SuspendLayout();
            panelTela.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelMenu.Controls.Add(btnMovimentacoes);
            panelMenu.Controls.Add(btnEstoque);
            panelMenu.Controls.Add(btnProdutos);
            panelMenu.Controls.Add(btnDashboard);
            panelMenu.Controls.Add(panelSeparador);
            panelMenu.Controls.Add(lblSubtituloMenu);
            panelMenu.Controls.Add(lblLogo);
            panelMenu.Location = new Point(0, 1);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(210, 610);
            panelMenu.TabIndex = 0;
            // 
            // btnMovimentacoes
            // 
            btnMovimentacoes.Location = new Point(0, 234);
            btnMovimentacoes.Name = "btnMovimentacoes";
            btnMovimentacoes.Size = new Size(210, 48);
            btnMovimentacoes.TabIndex = 4;
            btnMovimentacoes.Text = "Movimentações";
            btnMovimentacoes.UseVisualStyleBackColor = true;
            // 
            // btnEstoque
            // 
            btnEstoque.Location = new Point(0, 184);
            btnEstoque.Name = "btnEstoque";
            btnEstoque.Size = new Size(210, 48);
            btnEstoque.TabIndex = 3;
            btnEstoque.Text = "Estoque";
            btnEstoque.UseVisualStyleBackColor = true;
            // 
            // btnProdutos
            // 
            btnProdutos.Location = new Point(0, 134);
            btnProdutos.Name = "btnProdutos";
            btnProdutos.Size = new Size(210, 48);
            btnProdutos.TabIndex = 2;
            btnProdutos.Text = "Produtos";
            btnProdutos.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            btnDashboard.Location = new Point(0, 84);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(210, 48);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Visão geral";
            btnDashboard.UseVisualStyleBackColor = true;
            // 
            // panelSeparador
            // 
            panelSeparador.Location = new Point(0, 76);
            panelSeparador.Name = "panelSeparador";
            panelSeparador.Size = new Size(210, 1);
            panelSeparador.TabIndex = 5;
            // 
            // lblSubtituloMenu
            // 
            lblSubtituloMenu.AutoSize = true;
            lblSubtituloMenu.Location = new Point(19, 46);
            lblSubtituloMenu.Name = "lblSubtituloMenu";
            lblSubtituloMenu.Size = new Size(108, 15);
            lblSubtituloMenu.TabIndex = 6;
            lblSubtituloMenu.Text = "Gestão de estoque";
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Location = new Point(18, 18);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(79, 15);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "StockControl";
            // 
            // panelConteudo
            // 
            panelConteudo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelConteudo.Controls.Add(panelTela);
            panelConteudo.Controls.Add(lblTitulo);
            panelConteudo.Location = new Point(209, 1);
            panelConteudo.Name = "panelConteudo";
            panelConteudo.Size = new Size(773, 610);
            panelConteudo.TabIndex = 5;
            // 
            // panelTela
            // 
            panelTela.Controls.Add(lblPlaceholder);
            panelTela.Location = new Point(0, 45);
            panelTela.Name = "panelTela";
            panelTela.Size = new Size(773, 565);
            panelTela.TabIndex = 1;
            // 
            // lblPlaceholder
            // 
            lblPlaceholder.AutoSize = true;
            lblPlaceholder.Location = new Point(362, 241);
            lblPlaceholder.Name = "lblPlaceholder";
            lblPlaceholder.Size = new Size(12, 15);
            lblPlaceholder.TabIndex = 0;
            lblPlaceholder.Text = "-";
            lblPlaceholder.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(0, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(64, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Visão geral";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 611);
            Controls.Add(panelConteudo);
            Controls.Add(panelMenu);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StockControl";
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            panelConteudo.ResumeLayout(false);
            panelConteudo.PerformLayout();
            panelTela.ResumeLayout(false);
            panelTela.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Button btnDashboard;
        private Label lblLogo;
        private Button btnProdutos;
        private Button btnEstoque;
        private Button btnMovimentacoes;
        private Panel panelConteudo;
        private Label lblTitulo;
        private Panel panelTela;
        private Label lblPlaceholder;
        private Panel panelSeparador;
        private Label lblSubtituloMenu;
    }
}
