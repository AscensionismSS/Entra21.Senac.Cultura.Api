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
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ApplicationDbContext _context;

        public EnderecoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Endereco> BuscarEnderecoUnicoAsync(string cep, string bairro, string rua, string numero)
        {
            return await _context.Enderecos
                .FirstOrDefaultAsync(e => e.Cep == cep && e.Bairro == bairro && e.Rua == rua && e.Numero == numero);
        }

        public void CreateEndereco(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            
        }
    }
}


