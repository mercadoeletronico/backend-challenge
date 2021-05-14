using System.Collections.Generic;
using Domain.Entities;
using Domain.Notifications;
using Domain.Repositories;
using Infra.BD;

namespace Infra.Repositories.Queries
{
    public class PedidoQueryRepository : IPedidoQueryRepository
    {
        private readonly Banco _context;
        private readonly NotificationPool _notificationPool;

        public bool HasNotifications => _notificationPool.HasNotifications;

        public IReadOnlyCollection<Notification> Notifications => _notificationPool.Notifications;
        public PedidoQueryRepository(Banco context, NotificationPool notificationPool)
        {
            _context = context;
            _notificationPool = notificationPool;
        }


        public IEnumerable<Pedido> ListarPedido()
        {
            var retorno = _context.ListarPedidos();

            if (retorno.Count < 0)
            {
                _notificationPool.AddNotification("Pedido não encontrado!", NotificationLevel.Validation);
                return null;

            }
            return retorno;
        }

        public void RemoverPedido(string numeroPedido)
        {
            _context.RemoverPedido(numeroPedido);
        }

        public Pedido ListarPedidoByID(string idPedido)
        {
            return _context.ListarPedidoByID(idPedido);
        }
    }
}