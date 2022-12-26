using API_Filme.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace API_Filme.Data.DTOs.Cinema
{
    public class ReadCinemaDTO
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public Models.Endereco Endereco { get; set; }
        public Models.Gerente Gerente { get; set; }
    }
}
