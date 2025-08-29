using Cultura.Application.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Entra21.Senac.Cultura.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIngressoController : ControllerBase
    {
        private readonly ITipoIngressoService _tipoIngressoService;

        public TipoIngressoController(ITipoIngressoService tipoIngressoService)
        {
            _tipoIngressoService = tipoIngressoService;
        }

        

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var resultados = await _tipoIngressoService.GetAllAsync();
                return Ok(resultados);
            }
            catch (Exception) 
            {
                return StatusCode(500, new { message = "Ocorreu um erro interno ao buscar os dados." });
            }
        }
    }
}
