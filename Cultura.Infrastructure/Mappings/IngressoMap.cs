using Cultura.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Cultura.Infrastructure.Mappings
{
    public class IngressoMap : IEntityTypeConfiguration<Ingresso>
    {
        public void Configure(EntityTypeBuilder<Ingresso> builder)
        {
            builder.ToTable("Ingresso");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Preco).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(i => i.Quantidade).IsRequired();

            builder.HasOne(i => i.Evento)
                   .WithMany(e => e.Ingressos)
                   .HasForeignKey(i => i.EventoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.TipoIngresso)
                   .WithMany(t => t.Ingressos)
                   .HasForeignKey(i => i.TipoIngressoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}