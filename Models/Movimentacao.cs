using System;
using System.Collections.Generic;
using System.Text;

namespace StockControl.Models
{

    public enum TipoMovimentacao
    {
        Entrada = 1,
        Saida = 2
    }


    public class Movimentacao
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; } = string.Empty;
        public TipoMovimentacao Tipo { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public string? Observacao { get; set; }
        public string TipoDescricao => Tipo == TipoMovimentacao.Entrada ? "Entrada" : "Saída";
    }
}
