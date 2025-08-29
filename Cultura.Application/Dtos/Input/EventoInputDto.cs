using Cultura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cultura.Application.Dtos.Input
{
    public class EventoInputDto
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int CategoriaId { get; set; }
        public int UsuarioId { get; set; }
        public EnderecoInputDto Endereco { get; set; }

        public List<IngressoInputDto> Ingressos { get; set; }
    }
}
