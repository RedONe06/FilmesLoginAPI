using System.ComponentModel.DataAnnotations;

namespace API_Filme.Data.DTOs.Cinema
{
    public class CreateCinemaDTO
    {
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int EnderecoFK { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int GerenteFK { get; set; }
    }
}
