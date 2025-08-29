using Cultura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cultura.Infrastructure.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<Categoria> GetCategoriaById(int Id);
        Task<List<Categoria>> GetAllAsync();
    }
}
