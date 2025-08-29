using Cultura.Data;
using Cultura.Domain.Entities;
using Cultura.Infrastructure.Interfaces.Repositorio;
using Microsoft.EntityFrameworkCore;


namespace Cultura.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

            private readonly ApplicationDbContext _context;

            public UsuarioRepository(ApplicationDbContext context)
            {
                _context = context;
            }


        public void CreateUsuario(Usuario usuario)
        {
            
            _context.Usuarios.Add(usuario);
            
        }

        public void UpdateUsuario(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _context.Usuarios.Include(u => u.Endereco).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> LoginValidation(string email, string senha)
        {
            return await _context.Usuarios
                .Include(u => u.Endereco)
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
        }

    }
}
