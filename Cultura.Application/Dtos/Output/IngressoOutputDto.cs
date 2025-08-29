using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cultura.Application.Dtos.Output
{
    public class IngressoOutputDto
    {
        public int Id { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string TipoIngresso { get; set; } = string.Empty;
    }
}
