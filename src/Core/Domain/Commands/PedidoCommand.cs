using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Notifications;

namespace Domain.Commands
{
    public class PedidoCommand : ICommand
    {

        public string NumeroPedido { get; set; }
        public IEnumerable<PedidoItens> PedidoItens { get; set; }

        private readonly NotificationPool _notificationPool;
        public bool HasNotifications => _notificationPool.HasNotifications;

        public IReadOnlyCollection<Notification> Notifications => _notificationPool.Notifications;



        public PedidoCommand(string numeroPedido, IEnumerable<PedidoItens> pedidoItens)
        {
            _notificationPool = new NotificationPool();
            NumeroPedido = numeroPedido;
            PedidoItens = pedidoItens;
        }

        public void Validate()
        {
            _notificationPool.Reset();

            if (String.IsNullOrWhiteSpace(NumeroPedido))
                _notificationPool.AddNotification("Numero Pedido deve ser preenchido", NotificationLevel.Validation, "Pedido");

            if (PedidoItens.Count() < 0)
                _notificationPool.AddNotification("Os itens do pedido deve ser preenchido", NotificationLevel.Validation, "Itens");


        }
    }
}