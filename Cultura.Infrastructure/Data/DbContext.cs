using Cultura.Domain.Entities;
using Cultura.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Cultura.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets = tabelas no banco
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Ingresso> Ingressos { get; set; }
        public DbSet<TipoIngresso> TiposIngresso { get; set; }
        public DbSet<CompraIngresso> ComprasIngressos { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica os mapeamentos de cada entidade
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new EventoMap());
            modelBuilder.ApplyConfiguration(new IngressoMap());
            modelBuilder.ApplyConfiguration(new TipoIngressoMap());
            modelBuilder.ApplyConfiguration(new CompraIngressoMap());
            modelBuilder.ApplyConfiguration(new FavoritoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
