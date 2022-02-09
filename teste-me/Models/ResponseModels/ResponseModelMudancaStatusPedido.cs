using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste_me.Models.ResponseModels
{
    public class ResponseModelMudancaStatusPedido
    {
        [JsonProperty("pedido")]
        public string Pedido { get; set; }
        [JsonProperty("status")]
        public List<string> Status { get; set; } = new List<string>();


    }
}
