using API_Filme.Data.DTOs.Endereco;
using API_Filme.Models;
using AutoMapper;

namespace API_Filme.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<Endereco, ReadEnderecoDTO>();
            CreateMap<UpdateEnderecoDTO, Endereco>();
            CreateMap<CreateEnderecoDTO, Endereco>();
        }
    }
}
