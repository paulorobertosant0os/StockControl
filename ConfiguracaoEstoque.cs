using System;
using System.Collections.Generic;
using System.Text;

namespace StockControl
{
    internal static class ConfiguracaoEstoque
    {
        public const int MinimoPadrao = 10;
        public static int Minimo { get; set; } = MinimoPadrao;
    }
}
