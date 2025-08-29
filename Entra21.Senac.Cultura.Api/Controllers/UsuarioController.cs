using Cultura.Application.Dtos.Input;
using Cultura.Application.Interfaces.Service;
using Entra21.Senac.Cultura.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.Senac.Cultura.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        //[ValidarDto(typeof(UsuarioInputDto))]
        public async Task<IActionResult> AddUser([FromBody] UsuarioInputDto usuarioDto)
        {
            try
            {
                await _usuarioService.CreateUsuario(usuarioDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar usuário: {ex.Message}");
            }
        }




        [HttpPost("Login")]
        [ValidarDto(typeof(LoginInputDto))]
        public async Task<IActionResult> LoginValidation([FromBody] LoginInputDto login)
        {
            try
            {
                var usuario = await _usuarioService.LoginValidation(login);
                if (usuario == null)
                    return NotFound("Usuário não encontrado ou credenciais inválidas.");
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao validar login: {ex.Message}");
            }
        }
    }
}