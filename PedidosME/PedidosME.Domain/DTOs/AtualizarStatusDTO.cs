using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosME.Domain.DTOs
{
    public class AtualizarStatusDTO : IRequest<StatusPedidoDTO>
    {
        public string Status { get; set; }
        public float ItensAprovados { get; set; }
        public float ValorAprovado { get; set; }
        public string pedido { get; set; }
    }
}
