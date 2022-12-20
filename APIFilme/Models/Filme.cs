using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Filme.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public int ClassificacaoEtaria { get; set; }

        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}
