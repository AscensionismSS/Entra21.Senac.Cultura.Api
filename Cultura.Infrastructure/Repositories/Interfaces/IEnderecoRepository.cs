using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cultura.Domain.Entities;

namespace Cultura.Infrastructure.Repositories.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<Endereco> BuscarEnderecoUnicoAsync(string cep, string bairro, string rua, string numero);
        void CreateEndereco(Endereco endereco);

    }
}
