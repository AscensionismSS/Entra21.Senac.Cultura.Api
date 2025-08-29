using Cultura.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cultura.Infrastructure.Mappings
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("Evento");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Titulo).IsRequired().HasMaxLength(150);
            builder.Property(e => e.Descricao).HasMaxLength(500);
            builder.Property(e => e.Data).IsRequired();
            builder.Property(e => e.DataRegistro).IsRequired();

            builder.HasOne(e => e.Categoria)
                   .WithMany(c => c.Eventos)
                   .HasForeignKey(e => e.CategoriaId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Usuario)
                   .WithMany(u => u.EventosOrganizados)
                   .HasForeignKey(e => e.UsuarioId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Endereco)
                   .WithMany(e => e.Eventos)
                   .HasForeignKey(e => e.EnderecoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}