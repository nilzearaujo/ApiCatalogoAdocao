using ApiCatalgoAdocao.Domain;
using System;

namespace ApiCatalgoAdocao.ViewModel
{
    public class AnimalViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Tutora { get; set; }
        public int Idade { get; set; }
        public double Peso { get; set; }
        public EStatusAnimal Status { get; set; }
        public EPorteAnimal Porte { get; set; }
    }

    public enum EPorteAnimal
    {
        Pequeno = 1,
        Medio = 2,
        Grande = 3
    }

    public enum EStatusAnimal
    {
        Liberado = 1,
        Adotado = 2,
        Pendente = 3,
        Internado = 4
    }
}
