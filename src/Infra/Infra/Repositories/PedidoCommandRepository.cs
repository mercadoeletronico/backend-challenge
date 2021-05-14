using System.Collections.Generic;
using Domain.Commands;
using Domain.Notifications;
using Domain.Repositories;
using Infra.BD;

namespace Infra.Repositories
{
    public class PedidoCommandRepository : IPedidoCommandRepository
    {
        private readonly NotificationPool _notificationPool;
        public bool HasNotifications => _notificationPool.HasNotifications;
        private readonly Banco _context;

        public IReadOnlyCollection<Notification> Notifications => _notificationPool.Notifications;

        public PedidoCommandRepository(Banco context)
        {
            _notificationPool = new NotificationPool();
            _context = context;
        }

        public void CadastrarPedido(PedidoCommand command)
        {
            var retorno = _context.AdicionarPedido(command);
            if (retorno == false)
            {
                this._notificationPool.AddNotification("Numero de pedido ja cadastrado", NotificationLevel.Validation);

            }


        }
        public void AtualizarPedido(PedidoCommand command)
        {
            var retorno = _context.AlterarPedido(command);
            if (retorno == false)
            {
                this._notificationPool.AddNotification("Pedido não encontrado", NotificationLevel.Validation);

            }
        }
    }


}