using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cultura.Domain.Entities
{
    public class TipoIngresso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [JsonIgnore]
        public ICollection<Ingresso> Ingressos { get; set; }

        public TipoIngresso()
        {

        }
}
}
