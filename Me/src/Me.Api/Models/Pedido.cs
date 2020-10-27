using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Me.Api.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public List<Item> Itens { get; set; }
    }
}
