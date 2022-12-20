using API_Filme.Data.DTOs.Cinema;
using API_Filme.Models;
using AutoMapper;

namespace API_Filme.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<Cinema, CreateCinemaDTO>();
            CreateMap<ReadCinemaDTO, Cinema>();
            CreateMap<UpdateCinemaDTO, Cinema>();
        }
    }
}
