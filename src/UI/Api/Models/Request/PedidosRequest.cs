using System.Collections.Generic;

namespace Api.Models.Request
{
    public class PedidosRequest
    {
        public string Pedido { get; set; }
        public List<ItensPedido> Itens { get; set; }



    }
}