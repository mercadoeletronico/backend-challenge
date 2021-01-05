using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.Domain.Models
{
    public class PedidoStatusResponse
    {
        public PedidoStatusResponse()
        {
            if (this.Status == null)
                this.Status = new List<Status>();

        }

        public string Pedido { get; set; }

        public IList<Status> Status { get; set; }

        
        public PedidoStatusResponse RetornarStatusPedido(Pedido pedido)
        {
            this.Pedido = pedido.NumeroPedido;
            PedidoStatusResponse pedidoStatusResponse = new PedidoStatusResponse();
            this.Status = pedido.StatusPedido;
            return this;

        }
    }
}
