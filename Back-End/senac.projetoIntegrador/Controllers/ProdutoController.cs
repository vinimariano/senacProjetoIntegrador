using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senac.projetoIntegrador.Domain.Models;
using senac.projetoIntegrador.Domain.Repositories;
using senac.projetoIntegrador.Repositories.EmMemoria;

namespace senac.projetoIntegrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_produtoRepository.List());
        }

        [HttpPost]
        public IActionResult Create([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest();
            }            

            _produtoRepository.Create(produto);

            return Created("", produto.Id);
        }
    }
}
