using System.ComponentModel.DataAnnotations;

namespace Me.Api.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [MaxLength(500, ErrorMessage = "Esse campo deve conter no máximo")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal PrecoUnitario { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Qtd { get; set; }
    }
}
