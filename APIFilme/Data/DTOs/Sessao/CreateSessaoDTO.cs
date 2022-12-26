using System.ComponentModel.DataAnnotations;

namespace API_Filme.Data.DTOs.Sessao
{
    public class CreateSessaoDTO
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int CinemaFK { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int FilmeFK { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
