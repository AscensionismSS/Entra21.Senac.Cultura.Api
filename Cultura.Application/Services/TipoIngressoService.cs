using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cultura.Application.Dtos.Output;
using Cultura.Application.Interfaces.Service;
using Cultura.Domain.Entities;
using Cultura.Infrastructure.Repositories.Interfaces;

namespace Cultura.Application.Services
{
    public class TipoIngressoService : ITipoIngressoService

    {
        private readonly ITipoIngressoRepository _tipoIngressoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TipoIngressoService(ITipoIngressoRepository tipoIngressoRepository, IUnitOfWork unitOfWork)
        {
            _tipoIngressoRepository = tipoIngressoRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<List<TipoIngresso>> GetAllAsync()
        {
            return await _tipoIngressoRepository.GetAllAsync();
        }

        public async Task<TipoIngressoOutput> GetByIdAsync(int id)
        {
            var tipoIngresso = await _tipoIngressoRepository.GetByIdAsync(id);

            if (tipoIngresso == null)
                throw new ArgumentException($"Tipo de Ingresso com ID {id} não encontrado.");

            
            var outputDto = new TipoIngressoOutput
            {
                Id = tipoIngresso.Id,
                Nome = tipoIngresso.Nome,
                Descricao = tipoIngresso.Descricao
            };

            return outputDto;
        }


    }

}
