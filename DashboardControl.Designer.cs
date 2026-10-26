namespace StockControl
{
    partial class DashboardControl
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
            panelCards = new TableLayoutPanel();
            panelCard1 = new Panel();
            lblTotalRotulo = new Label();
            lblTotalValor = new Label();
            panelCard2 = new Panel();
            lblItensRotulo = new Label();
            lblItensValor = new Label();
            panelCard3 = new Panel();
            lblBaixoRotulo = new Label();
            lblBaixoValor = new Label();
            lblRecentes = new Label();
            gridRecentes = new DataGridView();
            panelCards.SuspendLayout();
            panelCard1.SuspendLayout();
            panelCard2.SuspendLayout();
            panelCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridRecentes).BeginInit();
            SuspendLayout();
            // 
            // panelCards
            // 
            panelCards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelCards.ColumnCount = 3;
            panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            panelCards.Controls.Add(panelCard1, 0, 0);
            panelCards.Controls.Add(panelCard2, 1, 0);
            panelCards.Controls.Add(panelCard3, 2, 0);
            panelCards.Location = new Point(0, 0);
            panelCards.Name = "panelCards";
            panelCards.RowCount = 1;
            panelCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelCards.Size = new Size(790, 100);
            panelCards.TabIndex = 0;
            // 
            // panelCard1
            // 
            panelCard1.Controls.Add(lblTotalRotulo);
            panelCard1.Controls.Add(lblTotalValor);
            panelCard1.Dock = DockStyle.Fill;
            panelCard1.Location = new Point(0, 0);
            panelCard1.Margin = new Padding(0, 0, 8, 0);
            panelCard1.Name = "panelCard1";
            panelCard1.Size = new Size(247, 100);
            panelCard1.TabIndex = 0;
            // 
            // lblTotalRotulo
            // 
            lblTotalRotulo.AutoSize = true;
            lblTotalRotulo.Location = new Point(16, 58);
            lblTotalRotulo.Name = "lblTotalRotulo";
            lblTotalRotulo.Size = new Size(123, 15);
            lblTotalRotulo.TabIndex = 1;
            lblTotalRotulo.Text = "Produtos Cadastrados";
            // 
            // lblTotalValor
            // 
            lblTotalValor.AutoSize = true;
            lblTotalValor.Location = new Point(16, 12);
            lblTotalValor.Name = "lblTotalValor";
            lblTotalValor.Size = new Size(13, 15);
            lblTotalValor.TabIndex = 0;
            lblTotalValor.Text = "0";
            // 
            // panelCard2
            // 
            panelCard2.Controls.Add(lblItensRotulo);
            panelCard2.Controls.Add(lblItensValor);
            panelCard2.Dock = DockStyle.Fill;
            panelCard2.Location = new Point(255, 0);
            panelCard2.Margin = new Padding(8, 0, 8, 0);
            panelCard2.Name = "panelCard2";
            panelCard2.Size = new Size(247, 100);
            panelCard2.TabIndex = 1;
            // 
            // lblItensRotulo
            // 
            lblItensRotulo.AutoSize = true;
            lblItensRotulo.Location = new Point(16, 58);
            lblItensRotulo.Name = "lblItensRotulo";
            lblItensRotulo.Size = new Size(121, 15);
            lblItensRotulo.TabIndex = 1;
            lblItensRotulo.Text = "Unidades em Estoque";
            // 
            // lblItensValor
            // 
            lblItensValor.AutoSize = true;
            lblItensValor.Location = new Point(16, 12);
            lblItensValor.Name = "lblItensValor";
            lblItensValor.Size = new Size(13, 15);
            lblItensValor.TabIndex = 0;
            lblItensValor.Text = "0";
            // 
            // panelCard3
            // 
            panelCard3.Controls.Add(lblBaixoRotulo);
            panelCard3.Controls.Add(lblBaixoValor);
            panelCard3.Dock = DockStyle.Fill;
            panelCard3.Location = new Point(510, 0);
            panelCard3.Margin = new Padding(8, 0, 0, 0);
            panelCard3.Name = "panelCard3";
            panelCard3.Size = new Size(247, 100);
            panelCard3.TabIndex = 2;
            // 
            // lblBaixoRotulo
            // 
            lblBaixoRotulo.AutoSize = true;
            lblBaixoRotulo.Location = new Point(16, 58);
            lblBaixoRotulo.Name = "lblBaixoRotulo";
            lblBaixoRotulo.Size = new Size(80, 15);
            lblBaixoRotulo.TabIndex = 1;
            lblBaixoRotulo.Text = "Estoque Baixo";
            // 
            // lblBaixoValor
            // 
            lblBaixoValor.AutoSize = true;
            lblBaixoValor.Location = new Point(16, 12);
            lblBaixoValor.Name = "lblBaixoValor";
            lblBaixoValor.Size = new Size(13, 15);
            lblBaixoValor.TabIndex = 0;
            lblBaixoValor.Text = "0";
            // 
            // lblRecentes
            // 
            lblRecentes.AutoSize = true;
            lblRecentes.Location = new Point(0, 116);
            lblRecentes.Name = "lblRecentes";
            lblRecentes.Size = new Size(139, 15);
            lblRecentes.TabIndex = 1;
            lblRecentes.Text = "Movimentações recentes";
            // 
            // gridRecentes
            // 
            gridRecentes.AllowUserToAddRows = false;
            gridRecentes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridRecentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridRecentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridRecentes.Location = new Point(0, 140);
            gridRecentes.Name = "gridRecentes";
            gridRecentes.ReadOnly = true;
            gridRecentes.RowHeadersVisible = false;
            gridRecentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridRecentes.Size = new Size(790, 440);
            gridRecentes.TabIndex = 2;
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridRecentes);
            Controls.Add(lblRecentes);
            Controls.Add(panelCards);
            Name = "DashboardControl";
            Size = new Size(790, 590);
            panelCards.ResumeLayout(false);
            panelCards.PerformLayout();
            panelCard1.ResumeLayout(false);
            panelCard1.PerformLayout();
            panelCard2.ResumeLayout(false);
            panelCard2.PerformLayout();
            panelCard3.ResumeLayout(false);
            panelCard3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridRecentes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel panelCards;
        private Panel panelCard1;
        private Label lblTotalValor;
        private Label lblTotalRotulo;
        private Panel panelCard2;
        private Label lblItensRotulo;
        private Label lblItensValor;
        private Panel panelCard3;
        private Label lblBaixoRotulo;
        private Label lblBaixoValor;
        private Label lblRecentes;
        private DataGridView gridRecentes;
    }
}
