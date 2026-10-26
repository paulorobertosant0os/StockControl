namespace StockControl
{
    partial class EstoqueControl
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
            lblPesquisar = new Label();
            txtPesquisa = new TextBox();
            lblMinimo = new Label();
            numEstoqueMinimo = new NumericUpDownEscuro();
            btnAtualizar = new Button();
            gridEstoque = new DataGridView();
            lblRodape = new Label();
            ((System.ComponentModel.ISupportInitialize)numEstoqueMinimo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridEstoque).BeginInit();
            SuspendLayout();
            // 
            // lblPesquisar
            // 
            lblPesquisar.AutoSize = true;
            lblPesquisar.Location = new Point(0, 0);
            lblPesquisar.Name = "lblPesquisar";
            lblPesquisar.Size = new Size(57, 15);
            lblPesquisar.TabIndex = 0;
            lblPesquisar.Text = "Pesquisar";
            // 
            // txtPesquisa
            // 
            txtPesquisa.Location = new Point(0, 22);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.Size = new Size(300, 25);
            txtPesquisa.TabIndex = 1;
            txtPesquisa.TextChanged += txtPesquisa_TextChanged_1;
            // 
            // lblMinimo
            // 
            lblMinimo.AutoSize = true;
            lblMinimo.Location = new Point(320, 0);
            lblMinimo.Name = "lblMinimo";
            lblMinimo.Size = new Size(94, 15);
            lblMinimo.TabIndex = 2;
            lblMinimo.Text = "Estoque mínimo";
            // 
            // numEstoqueMinimo
            // 
            numEstoqueMinimo.Location = new Point(320, 22);
            numEstoqueMinimo.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numEstoqueMinimo.Name = "numEstoqueMinimo";
            numEstoqueMinimo.Size = new Size(100, 28);
            numEstoqueMinimo.TabIndex = 3;
            numEstoqueMinimo.TextAlign = HorizontalAlignment.Right;
            numEstoqueMinimo.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numEstoqueMinimo.ValueChanged += numEstoqueMinimo_ValueChanged_1;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(440, 22);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(110, 28);
            btnAtualizar.TabIndex = 4;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click_1;
            // 
            // gridEstoque
            // 
            gridEstoque.AllowUserToAddRows = false;
            gridEstoque.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridEstoque.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridEstoque.Location = new Point(0, 70);
            gridEstoque.Name = "gridEstoque";
            gridEstoque.ReadOnly = true;
            gridEstoque.RowHeadersVisible = false;
            gridEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridEstoque.Size = new Size(790, 490);
            gridEstoque.TabIndex = 5;
            // 
            // lblRodape
            // 
            lblRodape.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblRodape.AutoSize = true;
            lblRodape.Location = new Point(0, 566);
            lblRodape.Name = "lblRodape";
            lblRodape.Size = new Size(72, 15);
            lblRodape.TabIndex = 6;
            lblRodape.Text = "0 produto(s)";
            // 
            // EstoqueControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblRodape);
            Controls.Add(gridEstoque);
            Controls.Add(btnAtualizar);
            Controls.Add(numEstoqueMinimo);
            Controls.Add(lblMinimo);
            Controls.Add(txtPesquisa);
            Controls.Add(lblPesquisar);
            Name = "EstoqueControl";
            Size = new Size(790, 590);
            ((System.ComponentModel.ISupportInitialize)numEstoqueMinimo).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridEstoque).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPesquisar;
        private TextBox txtPesquisa;
        private Label lblMinimo;
        private NumericUpDownEscuro numEstoqueMinimo;
        private Button btnAtualizar;
        private DataGridView gridEstoque;
        private Label lblRodape;
    }
}
