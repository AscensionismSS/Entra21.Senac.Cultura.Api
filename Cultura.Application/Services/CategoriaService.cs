using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cultura.Application.Interfaces.Service;
using Cultura.Domain.Entities;
using Cultura.Infrastructure.Repositories.Interfaces;

namespace Cultura.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaService(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork)
        {
            _categoriaRepository = categoriaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            return await _categoriaRepository.GetAllAsync();
        }

        public async Task<Categoria> GetCategoriaById(int id)
        {
            var categoria = await _categoriaRepository.GetCategoriaById(id);

            
            if (categoria == null)
            {
                throw new ArgumentException($"Categoria com ID {id} não encontrada.");
            }

            return categoria;
        }
    }
}
