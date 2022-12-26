using API_Filme.Data;
using API_Filme.Data.DTOs.Cinema;
using API_Filme.Data.DTOs.Sessao;
using API_Filme.Models;
using AutoMapper;
using Castle.Core.Internal;
using FluentResults;
using MySqlX.XDevAPI;

namespace API_Filme.Services
{
    public class SessaoService
    {
        IMapper _mapper;
        FilmeDbContext _context;

        public SessaoService(IMapper mapper, FilmeDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadSessaoDTO AdicionarSessao(CreateSessaoDTO sessaoDTO)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDTO);
            bool temNoBancoFK = ConferirBanco(sessaoDTO.CinemaFK, sessaoDTO.FilmeFK);

            if (!temNoBancoFK)
            {
                _context.Sessoes.Add(sessao);
                _context.SaveChanges();
                return _mapper.Map<ReadSessaoDTO>(sessao);
            }
            return null;
        }

        public List<ReadSessaoDTO> RecuperarSessoes()
        {
            List<Sessao> sessoes = _context.Sessoes.ToList();
            if(sessoes != null)
            {
                return _mapper.Map<List<ReadSessaoDTO>>(sessoes);
            }
            return null;
        }

        public ReadSessaoDTO RecuperarSessaoPorId(int id)
        {
            Sessao sessao = GetSessao(id);

            if (sessao != null)
            {
                ReadSessaoDTO readDTO = _mapper.Map<ReadSessaoDTO>(sessao);
                return readDTO;
            }
            return null;
        }

        public Result AtualizarSessao(int id, UpdateSessaoDTO sessaoDTO)
        {
            Sessao sessao = GetSessao(id);

            if (sessao != null)
            {
                _mapper.Map(sessaoDTO, sessao);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Não foi possível atualizar.");
        }

        public Result DeletarSessao(int id)
        {
            Sessao sessao = GetSessao(id);

            if (sessao != null)
            {
                _context.Remove(sessao);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Não foi possível atualizar.");
        }

        private Sessao GetSessao(int id)
        {
            return _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
        }

        private bool ConferirBanco(int cinemaFK, int filmeFK)
        {
            return _context.Sessoes.Any(sessao => sessao.CinemaFK == cinemaFK || sessao.FilmeFK == filmeFK);
        }
    }
}
