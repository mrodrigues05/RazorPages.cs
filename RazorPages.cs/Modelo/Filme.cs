﻿using System.ComponentModel.DataAnnotations;

namespace RazorPages.cs.Modelo
{
    public class Filme
    {
        public int ID { get; set; }
        public string Titulo { get; set; } = string.Empty;

        [Display(Name ="Data de lançamento")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }
        public string Genero { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Pontos { get; set; } = 0;
    }
}
