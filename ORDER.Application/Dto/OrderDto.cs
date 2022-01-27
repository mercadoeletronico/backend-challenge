using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ORDER.Application.Dto
{
    public class OrderDto
    {
        [JsonPropertyName("pedido")]
        public string OrderId { get; set; }
        
        [JsonPropertyName("itens")]
        public List<ItemDto> Items { get; set; }
    }
}