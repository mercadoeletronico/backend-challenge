using MediatR;
using PedidosME.Domain.PedidoAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosME.Domain.Events
{
    public class PedidoConsultadoEvent : INotification
    {
        public Pedido Pedido { get; set; }
        public PedidoConsultadoEvent(Pedido pedido)
        {
            Pedido = pedido;
        }

    }
}
