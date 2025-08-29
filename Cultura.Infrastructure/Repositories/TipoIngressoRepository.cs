using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cultura.Data;
using Cultura.Domain.Entities;
using Cultura.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cultura.Infrastructure.Repositories
{
    public class TipoIngressoRepository : ITipoIngressoRepository
    {
        private readonly ApplicationDbContext _context;
        public TipoIngressoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<TipoIngresso>> GetAllAsync()
        {
            return await _context.TiposIngresso.AsNoTracking().ToListAsync();
        }

        public async Task<TipoIngresso> GetByIdAsync(int id)
        {
            return await _context.TiposIngresso.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        // <-- MÉTODO ADICIONADO -->
        public async Task<List<TipoIngresso>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.TiposIngresso
                                 .Where(t => ids.Contains(t.Id))
                                 .AsNoTracking()
                                 .ToListAsync();
        }
    }
}

