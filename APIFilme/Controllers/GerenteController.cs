using API_Filme.Data.DTOs.Gerente;
using API_Filme.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Gerente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDTO gerenteDTO)
        {
            ReadGerenteDTO readDTO = _gerenteService.AdicionarGerente(gerenteDTO);
            return CreatedAtAction(nameof(RecuperarGerentePorId), new { id = readDTO.Id }, readDTO);
        }

        [HttpGet]
        public IActionResult RecuperarGerentes([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadGerenteDTO> readDTO = _gerenteService.RecuperarGerentes(classificacaoEtaria);

            if (readDTO != null)
            {
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorId(int id)
        {
            ReadGerenteDTO readDTO = _gerenteService.RecuperarGerenteId(id);

            if (readDTO != null)
            {
                return Ok(readDTO);
            }
            return NotFound(readDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            Result resultado = _gerenteService.DeletarGerente(id);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarGerente(int id, UpdateGerenteDTO gerenteDTO)
        {
            Result resultado = _gerenteService.AtualizarGerente(id, gerenteDTO);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
