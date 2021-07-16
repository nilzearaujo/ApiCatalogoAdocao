using System.ComponentModel.DataAnnotations;

namespace ApiCatalgoAdocao.Requests
{
    public class AnimalRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do animal deve ter pelo menos 3 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da tutora deve ter pelo menos 3 caracteres")]
        public string Tutora { get; set; }
        [Required]
        [Range(0, 30, ErrorMessage = "A idade do animal deve ser entre 0 e 30 anos")]
        public int Idade { get; set; }
        [Range(0, 100, ErrorMessage = "O peso do animal deve ser entre 0 e 100kg")]
        public double Peso { get; set; }
        [Range(1, 4, ErrorMessage = "O status do animal só tem 4 opções Liberado = 1, Adotado = 2, Pendente = 3, Internado = 4 ")]
        public int Status { get; set; }
        [Range(1, 3, ErrorMessage = "O porte do animal só tem 3 opções Pequeno = 1, Medio = 2, Grande = 3")]
        public int Porte { get; set; }
    }
}
