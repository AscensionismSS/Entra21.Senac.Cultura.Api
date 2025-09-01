using Cultura.Application.Dtos.Input;
using Cultura.Application.Dtos.Output;
using Cultura.Application.Interfaces.Service;
using Cultura.Domain.Entities;
using Entra21.Senac.Cultura.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.Senac.Cultura.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpPost]
        [ValidarDto(typeof(EventoInputDto))]
        public async Task<IActionResult> CreateEvento([FromBody] EventoInputDto evento)
        {
            try
            {
                
                await _eventoService.CreateEvento(evento);

                return StatusCode(201, new { message = "Evento criado com sucesso." });
            }
           
            catch (ArgumentException ex)
            {
               
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro interno no servidor." });
            }
        }
        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetEventosPorUsuarioId(int usuarioId)
        {
            var eventos = await _eventoService.GetEventosPorUsuarioId(usuarioId);

            if (eventos == null || !eventos.Any())
                return NotFound(new { Message = "Nenhum evento encontrado para este usuário." });

            return Ok(eventos);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoOutputDto>>> ObterTodosEventos()
        {
            var eventos = await _eventoService.ObterTodosEventos();
            return Ok(eventos);
        }
    }
}