using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MercadoEletronicoApi.Application.DTOs
{
    public class StatusResponseDTO
    {
        [JsonPropertyName("status")]
        public List<string> Status { get; set; }

        [JsonPropertyName("pedido")]
        public string PedidoId { get; set; }
    }
}
