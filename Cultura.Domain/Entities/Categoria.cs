using Cultura.Domain.Entities;
using System.Text.Json.Serialization;

namespace Cultura.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [JsonIgnore]
        public ICollection<Evento> Eventos { get; set; }

        [JsonIgnore]
        public ICollection<Favorito> Favoritos { get; set; }
    }

}