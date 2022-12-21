using API_Filme.Data;
using API_Filme.Data.DTOs.Gerente;
using API_Filme.Models;
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace API_Gerente.Services
{
    public class GerenteService
    {
        private IMapper _mapper;
        private FilmeDbContext _context;

        public GerenteService(FilmeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDTO AdicionarGerente(CreateGerenteDTO gerenteDTO)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDTO);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDTO>(gerente);
        }

        public List<ReadGerenteDTO> RecuperarGerentes(int? classificacaoEtaria)
        {
            List<Gerente> gerentes = _context.Gerentes.ToList();

            if (gerentes != null)
            {
                List<ReadGerenteDTO> readDTO = _mapper.Map<List<ReadGerenteDTO>>(gerentes);
                return readDTO;
            }
            return null;
        }

        public Result AtualizarGerente(int id, UpdateGerenteDTO gerenteDTO)
        {
            Gerente gerente = GetGerente(id);

            if (gerente != null)
            {
                _mapper.Map(gerenteDTO, gerente);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Gerente não encontrado");

        }

        public Result DeletarGerente(int id)
        {
            Gerente gerente = GetGerente(id);

            if (gerente != null)
            {
                _context.Remove(gerente);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Gerente não encontrado");
        }

        public ReadGerenteDTO RecuperarGerenteId(int id)
        {
            Gerente gerente = GetGerente(id);

            if (gerente != null)
            {
                return _mapper.Map<ReadGerenteDTO>(gerente);
            }
            return null;
        }

        private Gerente GetGerente(int id)
        {
            return _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
        }

    }
}
