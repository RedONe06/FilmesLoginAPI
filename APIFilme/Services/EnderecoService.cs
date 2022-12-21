using API_Filme.Data;
using API_Filme.Data.DTOs.Endereco;
using API_Filme.Models;
using AutoMapper;
using FluentResults;

namespace API_Filme.Services
{
    public class EnderecoService
    {
        private IMapper _mapper;
        private FilmeDbContext _context;

        public EnderecoService(IMapper mapper, FilmeDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadEnderecoDTO AdicionarEndereco(CreateEnderecoDTO enderecoDTO)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDTO);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDTO>(endereco);
        }

        public List<ReadEnderecoDTO> RecuperarEnderecos()
        {
            List<Endereco> enderecos = _context.Enderecos.ToList();

            if (enderecos != null)
            {
                return _mapper.Map<List<ReadEnderecoDTO>>(enderecos);
            }
            return null;
        }

        public Result AtualizarEndereco(int id, UpdateEnderecoDTO enderecoDTO)
        {
            Endereco endereco = GetEndereco(id);

            if (endereco != null)
            {
                _mapper.Map(enderecoDTO, endereco);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Endereço não encontrado");
        }

        public Result DeletarEndereco(int id)
        {
            Endereco endereco = GetEndereco(id);

            if (endereco != null)
            {
                _context.Remove(endereco);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Endereco não encontrado");
        }

        public ReadEnderecoDTO RecuperarEnderecosPorId(int id)
        {
            Endereco endereco = GetEndereco(id);

            if (endereco != null)
            {
                return _mapper.Map<ReadEnderecoDTO>(endereco);
            }
            return null;
        }

        private Endereco? GetEndereco(int id)
        {
            return _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        }
    }
}
