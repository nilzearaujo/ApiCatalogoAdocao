using System;

namespace ApiCatalgoAdocao.Domain
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Tutora { get; set; }
        public int Idade { get; set; }
        public double Peso { get; set; }
        public int Status { get; set; }
        public int Porte { get; set; }       
    }
}
