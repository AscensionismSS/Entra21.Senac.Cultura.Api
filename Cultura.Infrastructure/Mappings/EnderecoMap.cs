using Cultura.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cultura.Infrastructure.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Cep).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Estado).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Cidade).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Bairro).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Rua).IsRequired().HasMaxLength(150);
            builder.Property(e => e.Numero).IsRequired().HasMaxLength(10);
        }
    }
}