using System.ComponentModel.DataAnnotations;

namespace API_Filme.Data.DTOs.Endereco
{
    public class CreateEnderecoDTO
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Numero { get; set; }

    }
}
