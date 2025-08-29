using Cultura.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


namespace Cultura.Infrastructure.Mappings
{
    public class TipoIngressoMap : IEntityTypeConfiguration<TipoIngresso>
    {
        public void Configure(EntityTypeBuilder<TipoIngresso> builder)
        {
            builder.ToTable("TipoIngresso");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Descricao).HasMaxLength(300);

            builder.HasData(
            new TipoIngresso
            {
                Id = 1,
                Nome = "Normal",
                Descricao = "Acesso padrão ao evento. Garante entrada a todas as áreas comuns."
            },
            new TipoIngresso
            {
                Id = 2,
                Nome = "VIP",
                Descricao = "Acesso premium ao evento. Inclui benefícios exclusivos como área reservada, open bar e brindes especiais."
            }
        );

        }
    }
}