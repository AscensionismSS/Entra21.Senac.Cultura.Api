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
    public class IngressoRepository : IIngressoRepository
    {
        private readonly ApplicationDbContext _context;

        public IngressoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ingresso>> GetAllAsync()
        {
            
            return await _context.Ingressos.ToListAsync();
        }


        public void CreateIngresso(Ingresso ingresso)
        {
            _context.Ingressos.Add(ingresso);
        }
    }
}
    


