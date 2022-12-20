using System.ComponentModel.DataAnnotations;

namespace API_Filme.Data.DTOs.Cinema
{
    public class UpdateCinemaDTO
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }

        [DataType(((int)DataType.Custom))]
        public int Numero { get; set; }
    }
}
