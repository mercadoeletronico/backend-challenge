using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Requests.Pedido
{
    public class UpdatePedidoRequest : SavePedidoRequest
    {
        public long PedidoId { get; set; }

    }
}
