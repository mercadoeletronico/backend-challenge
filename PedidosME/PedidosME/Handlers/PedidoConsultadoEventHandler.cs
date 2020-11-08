using MediatR;
using MercadoEletronico.Utilities.Bus;
using PedidosME.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PedidosME.Handlers
{
    public class PedidoConsultadoEventHandler : INotificationHandler<PedidoConsultadoEvent>
    {
        private readonly IBusServices busServices;

        public PedidoConsultadoEventHandler(IBusServices busServices)
        {
            this.busServices = busServices;
        }
        public async Task Handle(PedidoConsultadoEvent notification, CancellationToken cancellationToken)
        {
            if (notification.Pedido == null)
            {
                await busServices.Send($"Pedido não encontrado.", cancellationToken);
            }
            else
            {
                await busServices.Send($"Pedido {notification.Pedido.Codigo} foi consultado.", cancellationToken);
            }
            
        }
    }
}
