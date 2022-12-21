using API_Filme.Data.DTOs.Gerente;
using API_Filme.Models;
using AutoMapper;

namespace API_Filme.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<Gerente, ReadGerenteDTO>();
            CreateMap<UpdateGerenteDTO, Gerente>();
            CreateMap<CreateGerenteDTO, Gerente>();
        }
    }
}
