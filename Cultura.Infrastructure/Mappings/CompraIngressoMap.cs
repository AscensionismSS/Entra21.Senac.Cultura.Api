using Cultura.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cultura.Infrastructure.Mappings
{
    public class CompraIngressoMap : IEntityTypeConfiguration<CompraIngresso>
    {
        public void Configure(EntityTypeBuilder<CompraIngresso> builder)
        {
            builder.ToTable("CompraIngresso");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.DataCompra).IsRequired();
            builder.Property(c => c.Quantidade).IsRequired();

            builder.HasOne(c => c.Usuario)
                   .WithMany(u => u.Compras)
                   .HasForeignKey(c => c.UsuarioId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Ingresso)
                   .WithMany(i => i.Compras)
                   .HasForeignKey(c => c.IngressoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}