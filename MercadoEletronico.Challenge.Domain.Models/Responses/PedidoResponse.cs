using System.Collections.Generic;

namespace MercadoEletronico.Challenge.Domain.Models.Responses
{
    public class PedidoResponse
    {
        public PedidoResponse()
        {
            Itens = new List<PedidoItemResponse>();
        }

        public string Pedido { get; set; }
        public List<PedidoItemResponse> Itens { get; set; }
    }
}
