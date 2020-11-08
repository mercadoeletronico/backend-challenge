using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosME.Domain.DTOs
{
    public class ConsultarPedidoDTO : IRequest<PedidoDTO>
    {
        public string CodigoPedido { get; set; }
    }
}
