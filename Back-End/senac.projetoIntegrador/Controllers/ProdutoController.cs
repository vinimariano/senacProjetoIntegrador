using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senac.projetoIntegrador.Domain.Models;
using senac.projetoIntegrador.Domain.Repositories;

namespace senac.projetoIntegrador.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepository _produtoRepository;
        private IPedidoRepository _pedidoRepository;

        public ProdutoController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository)
        {
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_produtoRepository.List());
        }

        [HttpGet]
        public IActionResult ListSuggestions()
        {
            string? loginUsuario = 
                User.Claims?
                .FirstOrDefault()?
                .Value;

            //Recebe os pedidos do usuário
            List<Pedido> pedidosUsuario = _pedidoRepository.List(loginUsuario);
            
            //Recebe os produtos que o usuário comprou
            List<Produto> produtosUsuario = new List<Produto>();
            foreach (Pedido pedido in pedidosUsuario)
                foreach (PedidoProduto pedidoProduto in pedido.Produtos)
                    produtosUsuario.Add(pedidoProduto.Produto);
            
            //Retira os repetidos
            produtosUsuario = produtosUsuario.Distinct().ToList();

            //Recebe as palavras-chave dos produtos comprados
            List<string> palavrasChave = new List<string>();
            foreach (Produto produto in produtosUsuario)
                foreach (string chave in produto.PalavrasChave.Split(','))
                    palavrasChave.Add(chave);

            //Retira os repetidos
            palavrasChave = palavrasChave.Distinct().ToList();

            //Busca os produtos relacionados às palavras-chave
            List<Produto> sugestoes = new List<Produto>();
            foreach(string palavraChave in palavrasChave)
            {
                List<Produto> produtosRelacionados = _produtoRepository.ListByKeyword(palavraChave);
                for(int i = 0;i < produtosRelacionados.Count;i++)
                {
                    if(!sugestoes.Any(t => t.Id == produtosRelacionados[i].Id))
                    {
                        sugestoes.Add(produtosRelacionados[i]);
                        break;
                    }
                }

                //Retorna 5 sugestões
                if (sugestoes.Count >= 5)
                    break;
            }

            return Ok(sugestoes);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest();
            }

            produto.Id =_produtoRepository.Create(produto);

            return Created("", produto.Id);
        }
    }
}
