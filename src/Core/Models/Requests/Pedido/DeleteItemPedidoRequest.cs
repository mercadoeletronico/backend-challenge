using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Requests.Pedido
{
    public class DeleteItemPedidoRequest
    {
        public int IdItemPedido { get; set; }

        public DeleteItemPedidoRequest(int idItemPedido)
        {
            IdItemPedido = idItemPedido;
        } 
    }
}
