using Cultura.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cultura.Infrastructure.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasIndex(u => u.Email)
                   .IsUnique();

            builder.Property(u => u.Senha)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Telefone)
                   .HasMaxLength(20);

            builder.Property(u => u.DataNascimento)
                   .IsRequired();

            builder.Property(u => u.DataRegistro)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()"); // SQL Server

            builder.Property(u => u.Tipo)
                    .HasConversion<int>()
                    .IsRequired();

            builder.HasOne(u => u.Endereco)
                   .WithMany(e => e.Usuarios)
                   .HasForeignKey(u => u.EnderecoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
