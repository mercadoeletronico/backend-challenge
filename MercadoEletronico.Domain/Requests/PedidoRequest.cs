using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercadoEletronico.Domain.Requests
{
    public class PedidoRequest
    {
        public PedidoRequest()
        {
            Itens = new List<PedidoItemRequest>();
        }

        public int Pedido { get; set; }

        public List<PedidoItemRequest> Itens { get; set; }
    }
}