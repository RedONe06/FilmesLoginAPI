using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Filme.Models
{
    public class Gerente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual List<Cinema> Cinemas { get; set; }
    }
}
