using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cultura.Application.Dtos.Input;
using Cultura.Domain.Entities;

namespace Cultura.Application.Interfaces.Service
{
    public interface IIngressoService
    {

        Task CreateIngresso(Ingresso ingresso);

    }
}
