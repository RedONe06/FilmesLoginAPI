using API_Filme.Data.DTOs.Sessao;
using API_Filme.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Sessao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDTO sessaoDTO)
        {
            ReadSessaoDTO readDTO = _sessaoService.AdicionarSessao(sessaoDTO);
            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { id = readDTO.Id }, readDTO);
        }

        [HttpGet]
        public IActionResult RecuperarSessaos()
        {
            List<ReadSessaoDTO> readDTO = _sessaoService.RecuperarSessoes();

            if (readDTO != null)
            {
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPorId(int id)
        {
            ReadSessaoDTO readDTO = _sessaoService.RecuperarSessaoPorId(id);

            if (readDTO != null)
            {
                return Ok(readDTO);
            }
            return NotFound(readDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarSessao(int id)
        {
            Result resultado = _sessaoService.DeletarSessao(id);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarSessao(int id, UpdateSessaoDTO sessaoDTO)
        {
            Result resultado = _sessaoService.AtualizarSessao(id, sessaoDTO);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
