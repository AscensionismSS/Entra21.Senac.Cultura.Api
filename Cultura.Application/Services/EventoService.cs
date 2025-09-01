using Cultura.Application.Dtos.Input;
using Cultura.Application.Dtos.Output;
using Cultura.Application.Interfaces.Service;
using Cultura.Domain.Entities;
using Cultura.Infrastructure.Data;
using Cultura.Infrastructure.Interfaces.Repositorio;
using Cultura.Infrastructure.Repositories;
using Cultura.Infrastructure.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cultura.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly ITipoIngressoRepository _tipoIngressoRepository;
        private readonly IIngressoRepository _ingressoRepository;
        private readonly IEventoRepository _eventoRepository;
        private readonly IEnderecoService _enderecoService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITipoIngressoService _tipoIngressoService;

        public EventoService(
            IIngressoRepository ingressoRepository,
            ITipoIngressoRepository tipoIngressoRepository,
            IEventoRepository eventoRepository,
            IEnderecoService enderecoService,
            IUsuarioRepository usuarioRepository,
            ICategoriaRepository categoriaRepository,
            IEnderecoRepository enderecoRepository,
            ITipoIngressoService tipoIngressoService,
            IUnitOfWork unitOfWork
        )
        {
            _tipoIngressoService = tipoIngressoService;
            _ingressoRepository = ingressoRepository;
            _tipoIngressoRepository = tipoIngressoRepository;
            _eventoRepository = eventoRepository;
            _enderecoService = enderecoService;
            _usuarioRepository = usuarioRepository;
            _categoriaRepository = categoriaRepository;
            _enderecoRepository = enderecoRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task CreateEvento(EventoInputDto eventoDto)
        {
            // --- 1. RESOLVER DEPENDÊNCIAS (buscar entidades de apoio) ---
            var endereco = await _enderecoService.VerificarEndereco(eventoDto.Endereco);

            if (endereco == null) throw new Exception("Endereço não pôde ser encontrado ou criado.");

            var usuario = await _usuarioRepository.GetUsuarioById(eventoDto.UsuarioId)
                          ?? throw new Exception($"Usuário não encontrado.");

            var categoria = await _categoriaRepository.GetCategoriaById(eventoDto.CategoriaId)
                            ?? throw new Exception($"Categoria não encontrada.");

            // --- 2. VALIDAR (Lógica de negócio DENTRO do Serviço) ---
            var tiposIngressoIds = eventoDto.Ingressos.Select(i => i.TipoIngressoId).Distinct().ToList();
            var tiposIngressoValidos = await _tipoIngressoRepository.GetByIdsAsync(tiposIngressoIds);

            if (tiposIngressoValidos.Count != tiposIngressoIds.Count)
            {
                throw new Exception("Um ou mais Tipos de Ingresso fornecidos são inválidos.");
            }


            var evento = new Evento(
                eventoDto.Titulo, eventoDto.Descricao, eventoDto.Data,
                 categoria.Id, usuario.Id, endereco
            );


            foreach (var ingressoDto in eventoDto.Ingressos)
            {

                if (ingressoDto.Preco < 0)
                {
                    throw new ArgumentException("O preço do ingresso não pode ser negativo.");
                }


                var novoIngresso = new Ingresso(
                    ingressoDto.Preco,
                    ingressoDto.Quantidade,
                    ingressoDto.TipoIngressoId
                );


                evento.Ingressos.Add(novoIngresso);
            }


            _eventoRepository.CreateEvento(evento);
            int linhasAfetadas = await _unitOfWork.CommitAsync();

            if (linhasAfetadas == 0)
                throw new Exception("Nenhuma alteração foi salva no banco de dados.");
        }

        public async Task<IEnumerable<EventoOutputDto>> GetEventosPorUsuarioId(int usuarioId)
        {
            var eventos = await _eventoRepository.GetEventosPorUsuarioId(usuarioId);

            return eventos.Select(e => new EventoOutputDto
            {
                Id = e.Id,
                Titulo = e.Titulo,
                Data = e.Data,
                Categoria = e.Categoria.Nome,

                Endereco = new EnderecoOutputDto
                {
                    Cep = e.Endereco.Cep,
                    Estado = e.Endereco.Estado,
                    Cidade = e.Endereco.Cidade,
                    Bairro = e.Endereco.Bairro,
                    Rua = e.Endereco.Rua,
                    Numero = e.Endereco.Numero
                },

                Ingressos = e.Ingressos.Select(i => new IngressoOutputDto
                {
                    Id = i.Id,
                    Preco = i.Preco,
                    Quantidade = i.Quantidade,
                    TipoIngresso = i.TipoIngresso.Nome
                }).ToList()
            }).ToList();
        }
        public async Task<IEnumerable<EventoOutputDto>> ObterTodosEventos()
        {
            var eventos = await _eventoRepository.GetAllEventos();

            return eventos.Select(e => new EventoOutputDto
            {
                Id = e.Id,
                Titulo = e.Titulo ?? string.Empty,
                Descricao = e.Descricao,
                Data = e.Data,
                Categoria = e.Categoria?.Nome ?? string.Empty,
                Endereco = e.Endereco != null ? new EnderecoOutputDto
                {
                    Cep = e.Endereco.Cep,
                    Estado = e.Endereco.Estado,
                    Cidade = e.Endereco.Cidade,
                    Bairro = e.Endereco.Bairro,
                    Rua = e.Endereco.Rua,
                    Numero = e.Endereco.Numero
                } : null,
                Ingressos = e.Ingressos?.Select(i => new IngressoOutputDto
                {
                    Id = i.Id,
                    Preco = i.Preco,
                    Quantidade = i.Quantidade,
                    TipoIngresso = i.TipoIngresso?.Nome
                }).ToList() ?? new List<IngressoOutputDto>()
            }).ToList();
        }


        public async Task<IEnumerable<EventoOutputDto>> GetEventosPorCategoria(int categoriaId)
        {
            // 1. Validação básica da regra de negócio
            if (categoriaId <= 0)
            {
                throw new ArgumentException("O ID da categoria fornecido é inválido.");
            }

            // 2. Chama o método do repositório para buscar os dados do banco
            var eventos = await _eventoRepository.GetByCategoria(categoriaId);

            // 3. Mapeia as entidades para DTOs para serem retornados pela API
            // Isso protege suas entidades de domínio e formata os dados para o frontend.
            var eventosDto = eventos.Select(evento => new EventoOutputDto
            {
                Id = evento.Id,
                Titulo = evento.Titulo,
                Descricao = evento.Descricao,
                Data = evento.Data,
                Categoria = evento.Categoria?.Nome, // Pega o nome da categoria
                Endereco = new EnderecoOutputDto
                {
                    Cep = evento.Endereco.Cep,
                    Estado = evento.Endereco.Estado,
                    Cidade = evento.Endereco.Cidade,
                    Bairro = evento.Endereco.Bairro,
                    Rua = evento.Endereco.Rua,
                    Numero = evento.Endereco.Numero
                },
                Ingressos = evento.Ingressos.Select(ing => new IngressoOutputDto
                {
                    Id = ing.Id,
                    Preco = ing.Preco,
                    Quantidade = ing.Quantidade,
                    TipoIngresso = ing.TipoIngresso?.Nome // Pega o nome do tipo de ingresso
                }).ToList()
            });

            // 4. Retorna a lista de DTOs
            return eventosDto;
        }
    }

}

