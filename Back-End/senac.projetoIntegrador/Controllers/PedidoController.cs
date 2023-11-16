using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senac.projetoIntegrador.Domain.Models;
using senac.projetoIntegrador.Domain.Repositories;
using static senac.projetoIntegrador.Domain.Models.ListaDePedido;

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
                return NotFound();
            }
            var Lista = new ListaDePedidos();

            var i = 0;
            decimal total = 0;
            while (i < pedido.Produtos.Count)
            {
                total = total + pedido.Produtos[i].Preco;
                i++;
            }
            pedido.Total = total;

            return Created("", pedido.Id);
        }
    }
}