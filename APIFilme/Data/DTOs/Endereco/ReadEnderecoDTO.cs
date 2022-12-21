﻿using System.ComponentModel.DataAnnotations;

namespace API_Filme.Data.DTOs.Endereco
{
    public class ReadEnderecoDTO
    {
        [Key]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
    }
}
