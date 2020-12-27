using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Requests.Pedido
{
    public class DeletePedidoRequest
    {
        public string CodigoPedido { get; set; }

        public DeletePedidoRequest(string codigoPedido)
        {
            CodigoPedido = codigoPedido;
        } 
    }
}
