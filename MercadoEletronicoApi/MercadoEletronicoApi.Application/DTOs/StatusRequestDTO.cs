using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MercadoEletronicoApi.Application.DTOs
{
    public class StatusRequestDTO
    {
        [Required]
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [Required]
        [JsonPropertyName("itensAprovados")]
        public int ApprovedItens { get; set; }

        [Required]
        [JsonPropertyName("valorAprovado")]
        public decimal ApprovedValue { get; set; }

        [Required]
        [JsonPropertyName("pedido")]
        public string OrderId { get; set; }
    }
}
