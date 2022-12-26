using System.ComponentModel.DataAnnotations;

namespace API_Filme.Models
{
    public class Sessao
    {
        [Key]
        public int Id { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
        public int FilmeFK { get; set; }
        public int CinemaFK { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}
