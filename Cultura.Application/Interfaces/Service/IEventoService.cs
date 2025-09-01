using Cultura.Application.Dtos.Input;
using Cultura.Application.Dtos.Output;
using Cultura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cultura.Application.Interfaces.Service
{
    public interface IEventoService
    {
        Task CreateEvento(EventoInputDto eventoDto);
        Task<IEnumerable<EventoOutputDto>> GetEventosPorUsuarioId(int usuarioId);
        Task<IEnumerable<EventoOutputDto>> ObterTodosEventos();
    }
}
