using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MercadoEletronicoApi.Application.DTOs
{
    public class ItemDTO
    {
        [Required]
        [JsonPropertyName("descricao")]
        public string Description { get; set; }

        [Required]
        [JsonPropertyName("precoUnitario")]
        public decimal UnitPrice { get; set; }

        [Required()]
        [JsonPropertyName("qtd")]
        public int Quantity { get; set; }
    }
}
