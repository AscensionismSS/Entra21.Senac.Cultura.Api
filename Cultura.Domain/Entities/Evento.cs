using Cultura.Domain.Entities;
using System.Text.Json.Serialization;


namespace Cultura.Domain.Entities
{
    public class Evento
    {
        public Evento() 
        {

        }

        public Evento(string titulo, string descricao, DateTime data, int categoriaId, int usuarioId, Endereco endereco)
        {
            Titulo = titulo;
            Descricao = descricao;
            Data = data;
            CategoriaId = categoriaId;
            UsuarioId = usuarioId;
            Endereco = endereco;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.Now;

        public int CategoriaId { get; set; }
        public int UsuarioId { get; set; } 
        public int EnderecoId { get; set; }

        [JsonIgnore]
        public Categoria Categoria { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; } 
        [JsonIgnore]
        public Endereco Endereco { get; set; }

        [JsonIgnore]
        public ICollection<Ingresso> Ingressos { get; private set; } = new List<Ingresso>();
    }

}