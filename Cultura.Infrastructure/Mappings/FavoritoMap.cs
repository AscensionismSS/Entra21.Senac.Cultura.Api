using Cultura.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Cultura.Infrastructure.Mappings
{
    public class FavoritoMap : IEntityTypeConfiguration<Favorito>
    {
        public void Configure(EntityTypeBuilder<Favorito> builder)
        {
            builder.ToTable("Favorito");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.DataFavorito).IsRequired();

            builder.HasOne(f => f.Usuario)
                   .WithMany(u => u.Favoritos)
                   .HasForeignKey(f => f.UsuarioId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Categoria)
                   .WithMany(c => c.Favoritos)
                   .HasForeignKey(f => f.CategoriaId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}