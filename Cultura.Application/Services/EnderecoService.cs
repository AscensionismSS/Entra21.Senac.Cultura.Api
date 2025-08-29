using Cultura.Application.Dtos.Input;
using Cultura.Application.Interfaces.Service;
using Cultura.Domain.Entities;
using Cultura.Infrastructure.Repositories;
using Cultura.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cultura.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository repository)
        {
            _enderecoRepository = repository;
        }

        public async Task<Endereco> VerificarEndereco(EnderecoInputDto enderecoDto)
        {
            var enderecoExistente = await _enderecoRepository.BuscarEnderecoUnicoAsync(
                enderecoDto.Cep,
                enderecoDto.Bairro,
                enderecoDto.Rua,
                enderecoDto.Numero
            );

            if (enderecoExistente == null)
            {
                var novoEndereco = new Endereco(
                    enderecoDto.Cep,
                    enderecoDto.Estado,
                    enderecoDto.Cidade,
                    enderecoDto.Bairro,
                    enderecoDto.Rua,
                    enderecoDto.Numero
                );
                _enderecoRepository.CreateEndereco(novoEndereco);
                return novoEndereco;
            }
            return enderecoExistente;
        }
    }
}
