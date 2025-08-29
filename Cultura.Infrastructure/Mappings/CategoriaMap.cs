using Cultura.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Cultura.Infrastructure.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Descricao).HasMaxLength(300);


            builder.HasData(
               new Categoria { Id = 1, Nome = "Shows", Descricao = "Eventos musicais, de bandas locais a shows nacionais." },
               new Categoria { Id = 2, Nome = "Teatro", Descricao = "Peças teatrais, do drama à comédia, para todos os públicos." },
               new Categoria { Id = 3, Nome = "Gastronomia", Descricao = "Festivais, workshops e experiências culinárias." },
               new Categoria { Id = 4, Nome = "Cinema", Descricao = "Estreias, pré-estreias e mostras especiais de filmes." },
               new Categoria { Id = 5, Nome = "Tecnologia", Descricao = "Palestras, workshops e hackathons sobre inovação." },
               new Categoria { Id = 6, Nome = "Encontros comunitários", Descricao = "Eventos para fortalecer a comunidade, como feiras e ações sociais." },
               new Categoria { Id = 7, Nome = "Humor", Descricao = "Shows de stand-up comedy e noites de microfone aberto." },
               new Categoria { Id = 8, Nome = "Exposições", Descricao = "Mostras de arte, fotografia e exposições históricas." },
               new Categoria { Id = 9, Nome = "Literatura", Descricao = "Lançamentos de livros, encontros de clubes de leitura e saraus." }
           );
        }
    }
}