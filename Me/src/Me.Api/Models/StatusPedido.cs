using System.ComponentModel.DataAnnotations;

namespace Me.Api.Models
{
    public class StatusPedido
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [MaxLength(500, ErrorMessage = "Esse campo deve conter no máximo")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public int ItensAprovados { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public int ValorAprovado { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [MaxLength(500, ErrorMessage = "Esse campo deve conter no máximo")]
        public string Pedido { get; set; }
    }
}