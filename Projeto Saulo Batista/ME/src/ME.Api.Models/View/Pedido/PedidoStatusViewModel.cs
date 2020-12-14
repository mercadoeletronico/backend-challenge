using ME.Api.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ME.Api.Models.View.Pedido
{
    public class PedidoStatusViewModel
    {
        public String NumPedido { get; set; }

        public List<String> Status { get; set; }
    }
}
