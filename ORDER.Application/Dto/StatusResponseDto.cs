using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ORDER.Application.Dto
{
    public class StatusResponseDto
    {
        [JsonPropertyName("pedido")]
        public string OrderId { get; set; }
        
        [JsonPropertyName("status")]
        public List<string> Status { get; set; }
    }
}