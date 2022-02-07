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
        public int ItensAprovados { get; set; }

        [Required]
        [JsonPropertyName("valorAprovado")]
        public decimal ValorAprovado { get; set; }

        [Required]
        [JsonPropertyName("pedido")]
        public string PedidoId { get; set; }
    }
}
