using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cultura.Domain.Entities
{
    public class Favorito
    {
        public int Id { get; set; }
        public DateTime DataFavorito { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }

        [JsonIgnore]
        public Categoria Categoria { get; set; }
    }
}
