using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercadoEletronico.Challenge.Domain.Models.Entities
{
    public class Pedido : IEntity
    {
        public Pedido()
        {
            Itens = new List<PedidoItem>();
        }

        public List<PedidoItem> Itens { get; set; }

        [JsonProperty("pedido")]
        public string Id { get; set; }
    }
}
