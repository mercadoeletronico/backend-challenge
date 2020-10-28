using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Me.Api.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [MaxLength(500, ErrorMessage = "Esse campo deve conter no máximo")]
        public string Pedido { get; set; }
        public List<Item> Itens { get; set; }
    }
}
