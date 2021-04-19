using System.Collections.Generic;

namespace MercadoEletronico.Challenge.Domain.Models.Resquests
{
    public class PedidoRequest
    {
        public PedidoRequest()
        {
            Itens = new List<PedidoItemRequest>();
        }

        public string Pedido { get; set; }
        public List<PedidoItemRequest> Itens { get; set; }
    }
}
