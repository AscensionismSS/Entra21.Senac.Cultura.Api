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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria> GetCategoriaById(int Id)
        {
            var categoria = await _context.Categorias.FindAsync(Id);
            return categoria;
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }
    }
}
