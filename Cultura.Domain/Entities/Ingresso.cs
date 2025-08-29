using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cultura.Domain.Entities
{
    public class Ingresso
    {
        public int Id { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        public int EventoId { get; set; }

        public int TipoIngressoId { get; set; }


        [JsonIgnore]
        public Evento Evento { get; set; }


        [JsonIgnore]
        public TipoIngresso TipoIngresso { get; set; }

        [JsonIgnore]
        public ICollection<CompraIngresso> Compras

        {
            get; set;
        }


        public Ingresso(decimal preco, int quantidade, int tipoIngressoId)
        {
            Preco = preco;
            Quantidade = quantidade;
            TipoIngressoId = tipoIngressoId;
        }

        public Ingresso() { }
    }
}




