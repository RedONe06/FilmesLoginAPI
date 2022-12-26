

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Filme.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        
        [JsonIgnore]
        public string Bairro { get; set; }

        [JsonIgnore]
        public int Numero { get; set; }

        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}
