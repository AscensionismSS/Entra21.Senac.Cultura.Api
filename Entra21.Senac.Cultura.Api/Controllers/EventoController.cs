using Cultura.Application.Dtos.Input;
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
                // Boa prática: O serviço pode retornar o objeto criado para mais informações.
                // Se seu método CreateEvento não retorna nada, pode ser apenas `await _eventoService.CreateEvento(evento);`
                await _eventoService.CreateEvento(evento);

                // A boa prática para criação é retornar 201 Created.
                // Se você não tiver um método para buscar o evento por ID, pode usar Ok() ou Created(uri, objeto).
                return StatusCode(201, new { message = "Evento criado com sucesso." });
            }
           
            catch (ArgumentException ex)
            {
                // Erro 400: Os dados enviados são inválidos (ex: tipo de ingresso inexistente, preço negativo).
                // A culpa também é do cliente.
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Erro 500: Um erro inesperado no servidor (ex: banco de dados offline).
                // A culpa é nossa. Em produção, você deveria LOGAR o 'ex' completo aqui.
                // NUNCA retorne ex.Message ou ex.InnerException para o cliente em produção por segurança.
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
    }
}