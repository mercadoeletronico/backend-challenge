using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendChallenge.Api.Model.Response
{
    public class OrderResponse
    {
        [Required]
        public string Pedido { get; set; }
        [Required]
        public List<ItemResponse> Items { get; set; }
    }
}