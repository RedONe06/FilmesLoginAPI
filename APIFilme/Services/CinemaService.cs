﻿using API_Filme.Data;
using API_Filme.Data.DTOs.Cinema;
using API_Filme.Models;
using AutoMapper;
using Castle.Core.Internal;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace API_Filme.Services
{
    public class CinemaService
    {
        private IMapper _mapper;
        private FilmeDbContext _context;

        public CinemaService(FilmeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDTO AdicionarCinema(CreateCinemaDTO cinemaDTO)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDTO>(cinema);
        }

        public List<ReadCinemaDTO> RecuperarCinemas(string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();

            if(!cinemas.IsNullOrEmpty())
            {
                if (!string.IsNullOrEmpty(nomeDoFilme))
                {
                    IEnumerable<Cinema> query = from cinema
                                                in cinemas
                                                where cinema.Sessoes
                                                    .Any(sessao => sessao.Filme.Titulo == nomeDoFilme)
                                                select cinema;

                    cinemas = query.ToList();
                }
                return _mapper.Map<List<ReadCinemaDTO>>(cinemas);
            }
            return null;
        }

        public ReadCinemaDTO RecuperarCinemaPorId(int id)
        {
            Cinema cinema = GetCinema(id);

            if(cinema != null)
            {
                ReadCinemaDTO readDTO = _mapper.Map<ReadCinemaDTO>(cinema);
                return readDTO;
            } 
            return null;
        }

        public Result AtualizarCinema(int id, UpdateCinemaDTO cinemaDTO)
        {
            Cinema cinema = GetCinema(id);

            if (cinema != null)
            {
                _mapper.Map(cinemaDTO, cinema);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Não foi possível atualizar.");
        }

        public Result DeletarCinema(int id)
        {
            Cinema cinema = GetCinema(id);

            if (cinema != null)
            {
                _context.Remove(cinema);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Não foi possível atualizar.");
        }

        private Cinema GetCinema(int id)
        {
            return _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        }
    }
}
