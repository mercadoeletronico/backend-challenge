using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendChallenge.Api.Model.Response
{
    public class OrderStatusResponse
    {
        [Required]
        public string Pedido { get; set; }
        [Required]
        public List<string> Status { get; set; }
    }
}