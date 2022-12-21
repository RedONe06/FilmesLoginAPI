using System.ComponentModel.DataAnnotations;

namespace API_Filme.Data.DTOs.Sessao
{
    public class UpdateSessaoDTO
    {
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
