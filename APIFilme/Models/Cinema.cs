using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Filme.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual Endereco Endereco { get; set; }
        public int EnderecoFK { get; set; }
        public virtual Gerente Gerente { get; set; }
        public int GerenteFK { get; set; }

        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}
