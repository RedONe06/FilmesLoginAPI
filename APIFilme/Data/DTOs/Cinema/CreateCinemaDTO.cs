using System.ComponentModel.DataAnnotations;

namespace API_Filme.Data.DTOs.Cinema
{
    public class CreateCinemaDTO
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }
        public int EnderecoFK { get; set; }
        public int GerenteFK { get; set; }
    }
}
