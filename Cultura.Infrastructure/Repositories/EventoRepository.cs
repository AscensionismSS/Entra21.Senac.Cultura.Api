using Cultura.Data;
using Cultura.Domain.Entities;
using Cultura.Infrastructure.Repositories.Interfaces;
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
    }
}
