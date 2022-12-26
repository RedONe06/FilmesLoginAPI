using API_Filme.Data;
using API_Filme.Data.DTOs.Filme;
using API_Filme.Models;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Filme.Services
{
    public class FilmeService
    {
        private FilmeDbContext _context;
        private IMapper _mapper;

        public FilmeService(FilmeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDTO AdicionarFilme(CreateFilmeDTO filmeDTO)
        {
            Filme filme = _mapper.Map<Filme>(filmeDTO);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDTO>(filme);
        }
        public List<ReadFilmeDTO> RecuperarFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;

            if (classificacaoEtaria != null)
            {
                filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }
            else{
                filmes = _context.Filmes.ToList();
            }
            

            if (filmes != null)
            {
                List<ReadFilmeDTO> readDTO = _mapper.Map<List<ReadFilmeDTO>>(filmes);
                return readDTO;
            }
            return null;
        }

        public Result AtualizarFilme(int id, UpdateFilmeDTO filmeDTO)
        {
            Filme filme = GetFilme(id);

            if (filme != null)
            {
                _mapper.Map(filmeDTO, filme);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Filme não encontrado");

        }

        public Result DeletarFilme(int id)
        {
            Filme filme = GetFilme(id);

            if (filme != null)
            {
                _context.Remove(filme);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Filme não encontrado");
        }

        public ReadFilmeDTO RecuperarFilmeId(int id)
        {
            Filme filme = GetFilme(id);

            if (filme != null)
            {
                return _mapper.Map<ReadFilmeDTO>(filme);
            }
            return null;
        }

        private Filme GetFilme(int id)
        {
            return _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        }
    }
}
