using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace ORDER.Application.Dto
{
    public class StatusResponseDto
    {
        [JsonPropertyName("pedido")] public string OrderId { get; set; }

        [JsonPropertyName("status")] public List<string> Status { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not StatusResponseDto item)
            {
                return false;
            }

            if (OrderId != item.OrderId || item.Status.Count != Status.Count)
                return false;

            return !Status.Where((t, i) => item.Status[i] != t).Any();
        }
    }
}