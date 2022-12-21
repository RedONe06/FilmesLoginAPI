using System.ComponentModel.DataAnnotations;

namespace API_Filme.Data.DTOs.Gerente
{
    public class CreateGerenteDTO
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }
    }
}
