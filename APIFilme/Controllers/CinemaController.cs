using API_Filme.Data.DTOs.Cinema;
using API_Filme.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace API_Filme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDTO cinemaDTO)
        {
            ReadCinemaDTO readDTO = _cinemaService.AdicionarCinema(cinemaDTO);
            if(readDTO != null)
            {
                return CreatedAtAction(nameof(RecuperarCinemaPorId), new { id = readDTO.Id }, readDTO);
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string? nomeDoFilme)
        {
            List<ReadCinemaDTO> readDTO = _cinemaService.RecuperarCinemas(nomeDoFilme);

            if(readDTO != null)
            {
                return Ok(readDTO);
            }
            return NotFound(readDTO);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaPorId(int id)
        {
            ReadCinemaDTO readDTO = _cinemaService.RecuperarCinemaPorId(id);

            if(readDTO != null)
            {
                return Ok(readDTO);
            }
            return NotFound(readDTO);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDTO cinemaDTO)
        {
            Result resultado = _cinemaService.AtualizarCinema(id, cinemaDTO);

            if (resultado.IsFailed)
            {
                return NotFound(resultado.Errors.FirstOrDefault());
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Result resultado = _cinemaService.DeletarCinema(id);

            if (resultado.IsFailed)
            {
                return NotFound(resultado.Errors.FirstOrDefault());
            }
            return NoContent();
        }

    }
}
