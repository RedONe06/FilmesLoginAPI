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
        
        [JsonIgnore]
        public virtual int EnderecoFK { get; set; }

        [JsonIgnore]
        public virtual Gerente Gerente { get; set; }

        [JsonIgnore]
        public virtual int GerenteFK { get; set; }

        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}
