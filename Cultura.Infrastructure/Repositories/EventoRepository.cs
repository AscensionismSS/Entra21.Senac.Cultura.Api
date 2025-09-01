// Importações necessárias para o funcionamento do código
using Cultura.Data;
using Cultura.Domain.Entities;
using Cultura.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cultura.Infrastructure.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ApplicationDbContext _context;


        public EventoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateEvento(Evento evento)
        {
            _context.Eventos.Add(evento);
        }

        public async Task<IEnumerable<Evento>> GetEventosPorUsuarioId(int usuarioId)
        {
            return await _context.Eventos
                                 .Where(e => e.UsuarioId == usuarioId)
                                 .Include(e => e.Categoria)
                                 .Include(e => e.Endereco)
                                 .Include(e => e.Ingressos)
                                    .ThenInclude(i => i.TipoIngresso)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Evento>> GetAllEventos()
        {
            return await _context.Eventos
                .Include(e => e.Categoria)
                .Include(e => e.Endereco)  
                .Include(e => e.Ingressos)
                    .ThenInclude(i => i.TipoIngresso)
                .Include(e => e.Usuario)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Evento>> GetByCategoria(int categoriaId)
        {
            
            return await _context.Eventos
                // 1. Inclui os dados da entidade Categoria relacionada.
                .Include(evento => evento.Categoria)
                .Include(evento => evento.Endereco)

                .Include(evento => evento.Ingressos)
                    .ThenInclude(ingresso => ingresso.TipoIngresso)
                .Where(evento => evento.CategoriaId == categoriaId)

                .ToListAsync();
        }
    }
}

