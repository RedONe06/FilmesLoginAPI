using API_Filme.Data.DTOs.Endereco;
using API_Filme.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Filme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDTO enderecoDTO)
        {
            ReadEnderecoDTO readDTO = _enderecoService.AdicionarEndereco(enderecoDTO);
            return CreatedAtAction(nameof(RecuperarEnderecosPorId), new { id = readDTO.Id }, readDTO);
        }

        [HttpGet]
        public IActionResult RecuperarEnderecos()
        {
            List<ReadEnderecoDTO> readDto = _enderecoService.RecuperarEnderecos();

            if (readDto == null)
            {
                return NotFound();
            }
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecosPorId(int id)
        {
            ReadEnderecoDTO readDTO = _enderecoService.RecuperarEnderecosPorId(id);

            if (readDTO == null)
            {
                return NotFound();
            }
            return Ok(readDTO);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDTO enderecoDTO)
        {
            Result resultado = _enderecoService.AtualizarEndereco(id, enderecoDTO);

            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            Result resultado = _enderecoService.DeletarEndereco(id);

            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
