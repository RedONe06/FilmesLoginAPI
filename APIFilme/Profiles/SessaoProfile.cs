using API_Filme.Data.DTOs.Gerente;
using API_Filme.Data.DTOs.Sessao;
using API_Filme.Models;
using AutoMapper;

namespace API_Filme.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<Sessao, ReadSessaoDTO>()
                .ForMember(dto => dto.HorarioDeInicio, opts => opts
                .MapFrom(dto =>
                dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao * (-1))));
          
            CreateMap<UpdateSessaoDTO, Sessao>();
            CreateMap<CreateSessaoDTO, Sessao>();
        }
    }
}
