using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste_me.Models.RequestModels
{
    public class RequestModelMudancaStatusPedido
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("itensAprovados")]
        public int ItensAprovados { get; set; }
        [JsonProperty("valorAprovado")]
        public decimal ValorAprovado { get; set; }
        [JsonProperty("pedido")]
        public int Pedido { get; set; }
    }
}
