using System.ComponentModel.DataAnnotations;

namespace API_Filme.Data.DTOs.Gerente
{
    public class ReadGerenteDTO
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public object Cinemas { get; set; }
    }
}
