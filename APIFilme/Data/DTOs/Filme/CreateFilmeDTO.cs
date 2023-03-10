using System.ComponentModel.DataAnnotations;

namespace API_Filme.Data.DTOs.Filme
{
    public class CreateFilmeDTO
    {
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "O gênero não pode passar de 40 caracteres")]
        public string Genero { get; set; }

        [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 e no máximo 600 minutos")]
        public int Duracao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int ClassificacaoEtaria { get; set; }
    }
}
