using API_Filme.Data.DTOs.Filme;
using API_Filme.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API_Filme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {

        private FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        
        [HttpPost]
        [Authorize(Roles = "manager")]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDTO filmeDTO)
        {
            ReadFilmeDTO readDTO = _filmeService.AdicionarFilme(filmeDTO);
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { id = readDTO.Id }, readDTO);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null) 
        {
            List<ReadFilmeDTO> readDTO = _filmeService.RecuperarFilmes(classificacaoEtaria);

            if(readDTO != null)
            {
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            ReadFilmeDTO readDTO = _filmeService.RecuperarFilmeId(id);

            if(readDTO != null)
            {
                return Ok(readDTO);
            }
            return NotFound(readDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Result resultado = _filmeService.DeletarFilme(id);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, UpdateFilmeDTO filmeDTO)
        {
            Result resultado = _filmeService.AtualizarFilme(id, filmeDTO);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
