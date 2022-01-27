using System.Text.Json.Serialization;

namespace ORDER.Application.Dto
{
    public class ItemDto
    {
        [JsonPropertyName("descricao")]
        public string Description { get; set; }
        
        [JsonPropertyName("precoUnitario")]
        public int UnitPrice { get; set; }
        
        [JsonPropertyName("qtd")]
        public int Quantity { get; set; }
    }
}