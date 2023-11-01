using senac.projetoIntegrador.Domain.Models;
using senac.projetoIntegrador.Domain.Repositories;

namespace senac.projetoIntegrador.Repositories.EmMemoria
{
    public class ProdutoRepository : IProdutoRepository
    {
        private static List<Produto> _bancoDeDados = new List<Produto>
        {
            new Produto
            {
                Id = 1,
                Nome = "Hambúrguer Clássico",
                Descricao = "Um hambúrguer clássico com carne grelhada, alface, tomate e queijo cheddar.",
                Preco = 9.99M,
                CaminhoImagem = "/imagens/hamburguer1.jpg"
            }
        };

        public List<Produto> List()
        {
            return _bancoDeDados;
        }
    }
}
