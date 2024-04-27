using senac.projetoIntegrador.Domain.Models;

namespace senac.projetoIntegrador.Repositories.Models
{
    internal class tabelaPedidoProduto
    {
        public tabelaPedidoProduto(PedidoProduto pedidoProduto, int idPedido)
        {
            IdPedido = idPedido;
            IdProduto = pedidoProduto.Produto.Id;
            Preco = pedidoProduto.Produto.Preco;
            QuantidadeProduto = pedidoProduto.Quantidade;
        }

        public tabelaPedidoProduto()
        {            
        }

        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeProduto { get; set; }

        //Dados do Produto
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string CaminhoImagemProduto { get; set; }
        public string PalavrasChaveProduto { get; set; }

        public PedidoProduto Mapear()
        {
            return new PedidoProduto()
            {
                Produto = new Produto()
                {
                    Id = IdProduto,
                    Preco = Preco,
                    Nome = NomeProduto,
                    Descricao = DescricaoProduto,
                    CaminhoImagem = CaminhoImagemProduto,
                    PalavrasChave = PalavrasChaveProduto
                },
                Quantidade = QuantidadeProduto
            };
        }
    }
}
