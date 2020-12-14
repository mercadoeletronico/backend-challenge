using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ME.Api.Models.View.Pedido
{
    public class PedidoStatusRequest : IRequest<IActionResult>
    {
        public String Status { get; set; }
        public String NumPedido { get; set; }
        public int ItensAprovados { get; set; }
        public decimal ValorAprovado { get; set; }

    }
}
