using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ORDER.Domain.Dto
{
    public class ItemDto
    {
        [Required]
        [JsonPropertyName("descricao")]
        public string Description { get; set; }
        
        [Required]
        [JsonPropertyName("precoUnitario")]
        public int UnitPrice { get; set; }
        
        [Required]
        [JsonPropertyName("qtd")]
        public int Quantity { get; set; }
    }
}