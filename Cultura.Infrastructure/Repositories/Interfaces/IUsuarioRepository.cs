using Cultura.Domain.Entities;

namespace Cultura.Infrastructure.Interfaces.Repositorio
{
    public interface IUsuarioRepository
    {
        void CreateUsuario(Usuario usuario);

        void UpdateUsuario(Usuario usuario);


        Task<Usuario> GetUsuarioById(int id);

        Task<Usuario> LoginValidation(string email, string senha);
    }
}
