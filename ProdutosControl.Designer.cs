namespace StockControl
{
    partial class ProdutosControl
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
            btnNovo = new Button();
            btnEditar = new Button();
            btnExcluir = new Button();
            btnMovimentar = new Button();
            gridProdutos = new DataGridView();
            lblRodape = new Label();
            ((System.ComponentModel.ISupportInitialize)gridProdutos).BeginInit();
            SuspendLayout();
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(0, 0);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(100, 36);
            btnNovo.TabIndex = 0;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(108, 0);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 36);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(216, 0);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(100, 36);
            btnExcluir.TabIndex = 2;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnMovimentar
            // 
            btnMovimentar.Location = new Point(324, 0);
            btnMovimentar.Name = "btnMovimentar";
            btnMovimentar.Size = new Size(140, 36);
            btnMovimentar.TabIndex = 3;
            btnMovimentar.Text = "Movimentar";
            btnMovimentar.UseVisualStyleBackColor = true;
            btnMovimentar.Click += btnMovimentar_Click;
            // 
            // gridProdutos
            // 
            gridProdutos.AllowUserToAddRows = false;
            gridProdutos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridProdutos.Location = new Point(0, 52);
            gridProdutos.Name = "gridProdutos";
            gridProdutos.ReadOnly = true;
            gridProdutos.Size = new Size(790, 506);
            gridProdutos.TabIndex = 4;
            // 
            // lblRodape
            // 
            lblRodape.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblRodape.AutoSize = true;
            lblRodape.Location = new Point(0, 566);
            lblRodape.Name = "lblRodape";
            lblRodape.Size = new Size(72, 15);
            lblRodape.TabIndex = 5;
            lblRodape.Text = "0 produto(s)";
            // 
            // ProdutosControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblRodape);
            Controls.Add(gridProdutos);
            Controls.Add(btnMovimentar);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(btnNovo);
            Name = "ProdutosControl";
            Size = new Size(790, 590);
            ((System.ComponentModel.ISupportInitialize)gridProdutos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnNovo;
        private Button btnEditar;
        private Button btnExcluir;
        private Button btnMovimentar;
        private DataGridView gridProdutos;
        private Label lblRodape;
    }
}
