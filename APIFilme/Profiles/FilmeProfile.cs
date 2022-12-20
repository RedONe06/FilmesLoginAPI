using API_Filme.Data.DTOs.Filme;
using API_Filme.Models;
using AutoMapper;

namespace API_Filme.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<UpdateFilmeDTO, Filme>();
            CreateMap<Filme, ReadFilmeDTO>();
        }
    }
}
