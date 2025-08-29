using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cultura.Application.Interfaces.Service;
using Cultura.Domain.Entities;
using Cultura.Infrastructure.Repositories.Interfaces;

namespace Cultura.Application.Services
{
    public class IngressoService : IIngressoService
    {
        private readonly IIngressoRepository _ingressoRepository;

        public IngressoService(IIngressoRepository ingressoRepository)
        {
            _ingressoRepository = ingressoRepository;
        }

        public async Task CreateIngresso(Ingresso ingresso)
        {
             _ingressoRepository.CreateIngresso(ingresso);
        }

    }
}
