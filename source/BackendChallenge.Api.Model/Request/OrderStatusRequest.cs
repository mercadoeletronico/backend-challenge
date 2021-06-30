using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendChallenge.Api.Model.Request
{
    public class OrderStatusRequest
    {
        [Required]
        public string Status { get; set; }
        public int ItensAprovados { get; set; }
        public int ValorAprovado { get; set; }
        [Required]
        public string Pedido { get; set; }
    }
}