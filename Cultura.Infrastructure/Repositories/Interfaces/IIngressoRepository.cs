using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cultura.Domain.Entities;

namespace Cultura.Infrastructure.Repositories.Interfaces
{
    public interface IIngressoRepository
    {
        Task<List<Ingresso>> GetAllAsync();

        void CreateIngresso(Ingresso ingresso);
    }
}
