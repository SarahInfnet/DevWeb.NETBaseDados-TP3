using System;
using System.Collections.Generic;

namespace DesenvolvimentoWebDotNETBasesDados_TP3.Models
{
    public class Aventureiro
    {
        public int AventureiroID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }

        public ICollection<Investidura> Investiduras { get; set; }
    }
}