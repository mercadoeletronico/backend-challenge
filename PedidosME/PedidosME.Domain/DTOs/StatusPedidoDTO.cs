using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosME.Domain.DTOs
{
    public class StatusPedidoDTO
    {
        public string Pedido { get; set; }
        public IEnumerable<string> Status { get; set; }
    }
}
