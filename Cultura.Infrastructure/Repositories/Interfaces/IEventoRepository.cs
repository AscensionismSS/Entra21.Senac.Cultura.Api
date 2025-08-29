using Cultura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cultura.Infrastructure.Repositories.Interfaces
{
    public interface IEventoRepository
    {
        void CreateEvento(Evento evento);
    }
}
