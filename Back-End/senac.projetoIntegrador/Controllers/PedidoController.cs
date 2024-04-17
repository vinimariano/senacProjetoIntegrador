using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senac.projetoIntegrador.Domain.Models;
using senac.projetoIntegrador.Domain.Repositories;

namespace senac.projetoIntegrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Pedido pedido)
        {
            if (pedido == null || pedido.Produtos.Any() != true)
            {
                return BadRequest();
            }

            int i = 0;
            decimal total = 0;
            while (i < pedido.Produtos.Count)
            {
                total = total + (pedido.Produtos[i].Produto.Preco * pedido.Produtos[i].Quantidade);
                i++;
            }
            pedido.Total = total;

            pedido.Id = _pedidoRepository.Create(pedido);

            return Created("", pedido.Id);
        }
    }
}