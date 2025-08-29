using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cultura.Domain.Entities;

namespace Cultura.Application.Interfaces.Service
{
    public interface ICategoriaService
    {
        Task<Categoria> GetCategoriaById(int Id);
        Task<List<Categoria>> GetAllAsync();
    }
}
