using System.ComponentModel.DataAnnotations;

namespace API_Filme.Data.DTOs.Sessao
{
    public class UpdateSessaoDTO
    {
        public int CinemaFK { get; set; }
        public int FilmeFK { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
