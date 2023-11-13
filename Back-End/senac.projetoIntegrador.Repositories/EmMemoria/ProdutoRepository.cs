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
                Nome = "Classic Burguer",
                Descricao = "Um hambúrguer de carne grelhada, alface, tomate e queijo cheddar.",
                Preco = 9.99M,
                CaminhoImagem = "/src/assets/burger5.png"
            },
            new Produto
            {
                Id = 2,
                Nome = "Cheesebuguer",
                Descricao = "Hambúrguer de carne, queijo, alface, tomate e maionese em um pão de hambúrguer.",
                Preco = 8.99M,
                CaminhoImagem = "/src/assets/burger1.png"
            },
            new Produto
            {
                Id = 3,
                Nome = "Bacon Burguer",
                Descricao = "Hambúrguer de carne coberto com bacon crocante, queijo, alface, tomate e maionese, servido em um pão de hambúrguer.",
                Preco = 9.99M,
                CaminhoImagem = "/src/assets/burger2.png"
            },
            new Produto
            {
                Id = 3,
                Nome = "Veggie Burguer",
                Descricao = "Hambúrguer vegetariano à base de vegetais, acompanhado de queijo, alface, tomate e maionese em um pão de hambúrguer.",
                Preco = 6.99M,
                CaminhoImagem = "/src/assets/burger6.png"
            },
            new Produto
            {
                Id = 3,
                Nome = "Double Cheeseburger",
                Descricao = "Dois hambúrgueres de carne, dupla porção de queijo, alface, tomate e maionese, servidos em um pão de hambúrguer.",
                Preco = 10.99M,
                CaminhoImagem = "/src/assets/burger4.png"
            }
        };

        public List<Produto> List()
        {
            return _bancoDeDados;
        }
    }
}
