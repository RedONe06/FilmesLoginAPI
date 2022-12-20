using System.ComponentModel.DataAnnotations;

namespace API_Filme.Data.DTOs.Filme
{
    public class UpdateFilmeDTO
    {
        public string Titulo { get; set; }
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "O gênero não pode passar de 40 caracteres")]
        public string Genero { get; set; }

        [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 e no máximo 600 minutos")]
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
    }
}
