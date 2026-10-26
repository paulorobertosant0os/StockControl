using StockControl.Models;


namespace StockControl.Data
{
    internal class DashboardRepositorio
    {
        private readonly ProdutoRepositorio _produtos = new();
        private readonly MovimentacaoRepositorio _movimentacoes = new();

        public ResumoDashboard ObterResumo(int limiteEstoqueBaixo,int quantidadeMovimentacoes = 10)
        {
            List<Produto> produtos = _produtos.Listar();
            List<Movimentacao> movimentacoes = _movimentacoes.ListarRecentes();

            return new ResumoDashboard
            {
                TotalProdutosAtivos = produtos.Count,
                TotalUnidadesEmEstoque = produtos.Sum(p => p.Quantidade),
                ProdutosEstoqueBaixo = produtos.Count(p => p.Quantidade < limiteEstoqueBaixo),
                MovimentacoesRecentes = movimentacoes.Take(quantidadeMovimentacoes).ToList()
            };
        }
    }
}
