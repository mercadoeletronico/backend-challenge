using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MercadoEletronicoApi.Application.DTOs
{
    public class ItemDTO
    {
        [Required]
        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }

        [Required]
        [JsonPropertyName("precoUnitario")]
        public decimal PrecoUnitario { get; set; }

        [Required()]
        [JsonPropertyName("qtd")]
        public int Quantidade { get; set; }
    }
}
