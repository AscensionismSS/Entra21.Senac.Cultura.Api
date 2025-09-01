using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cultura.Application.Dtos.Output
{
    public class EventoOutputDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string Categoria { get; set; } = string.Empty;

        // Agora o evento retorna o objeto completo de endereço
        public EnderecoOutputDto Endereco { get; set; }

        public List<IngressoOutputDto> Ingressos { get; set; } = new();
    }
}
