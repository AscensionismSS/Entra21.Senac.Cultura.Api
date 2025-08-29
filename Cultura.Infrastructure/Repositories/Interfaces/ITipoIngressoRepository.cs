using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cultura.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cultura.Infrastructure.Repositories.Interfaces
{
    public interface ITipoIngressoRepository
    {

        Task<List<TipoIngresso>> GetAllAsync();
        Task<TipoIngresso> GetByIdAsync(int id);
        Task<List<TipoIngresso>> GetByIdsAsync(IEnumerable<int> ids);
    }
}
