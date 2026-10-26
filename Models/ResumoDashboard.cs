using System;
using System.Collections.Generic;
using System.Text;

namespace StockControl.Models
{
    public class ResumoDashboard
    {
        public int TotalProdutosAtivos { get; set; }
        public int TotalUnidadesEmEstoque { get; set; }
        public int ProdutosEstoqueBaixo { get; set; }

        public List<Movimentacao> MovimentacoesRecentes { get; set; } = new();
    }
}
