using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ORDER.Domain.Dto
{
    public class OrderDto
    {
        [Required]
        [JsonPropertyName("pedido")]
        public string OrderId { get; set; }

        [Required]
        [JsonPropertyName("itens")]
        public List<ItemDto> Items { get; set; }
    }
}