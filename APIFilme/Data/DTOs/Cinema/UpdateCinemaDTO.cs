using System.ComponentModel.DataAnnotations;

namespace API_Filme.Data.DTOs.Cinema
{
    public class UpdateCinemaDTO
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}
