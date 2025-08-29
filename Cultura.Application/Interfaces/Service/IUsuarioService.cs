using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cultura.Application.Dtos.Input;
using Cultura.Application.Dtos.Output;
using Cultura.Domain.Entities;

namespace Cultura.Application.Interfaces.Service
{
    public interface IUsuarioService
    {
        Task CreateUsuario(UsuarioInputDto usuarioCreateDto);

        Task<UsuarioOutputDto> LoginValidation(LoginInputDto login);
    }
}
