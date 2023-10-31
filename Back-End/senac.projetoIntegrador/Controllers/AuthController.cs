using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using senac.projetoIntegrador.Authentication;
using senac.projetoIntegrador.Models;

namespace senac.projetoIntegrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private JwtSettings _settings;
        private ConfigureJwt _configureJwt;
        public AuthController(JwtSettings settings, ConfigureJwt configureJwt)
        {
            _settings = settings;    
            _configureJwt = configureJwt;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody]Usuario usuario)
        {
            if
            (
                usuario != null &&
                usuario.Login.ToLower() == "senac" &&
                usuario.Senha.ToLower() == _settings.SenhaPadrao.ToLower()
            )
            {
                return Ok(new 
                { 
                    BearerToken = _configureJwt.BuildJwtToken(usuario.Login)
                });
            }
            else
                return StatusCode(StatusCodes.Status401Unauthorized);
        }
    }
}
