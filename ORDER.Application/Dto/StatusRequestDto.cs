using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ORDER.Application.Dto
{
    public class StatusRequestDto
    {
        [Required]
        [JsonPropertyName("status")]
        public string Status { get; set; }
        
        [Required]
        [JsonPropertyName("itensAprovados")]
        public int ApprovedItems { get; set; }
        
        [Required]
        [JsonPropertyName("valorAprovado")]
        public int ApprovedValue  { get; set; }
        
        [Required]
        [JsonPropertyName("pedido")]
        public string OrderId { get; set; }
    }
}