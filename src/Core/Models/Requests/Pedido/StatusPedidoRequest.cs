using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Requests.Pedido
{
    public class StatusPedidoRequest
    {
        public string Status { get; set; }
        public int ItensAprovados { get; set; }
        public double ValorAprovado { get; set; }
        public string Pedido { get; set; }

    }
}
