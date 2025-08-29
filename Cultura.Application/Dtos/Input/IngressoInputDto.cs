using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cultura.Application.Dtos.Input
{
    public class IngressoInputDto
    {
        public int TipoIngressoId { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
