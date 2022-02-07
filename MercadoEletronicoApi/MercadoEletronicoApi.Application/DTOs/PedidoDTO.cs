using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MercadoEletronicoApi.Application.DTOs
{
    public class PedidoDTO
    {
        [Required]
        [JsonPropertyName("pedido")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("itens")]
        public IList<ItemDTO> Items { get; set; }
    }
}
