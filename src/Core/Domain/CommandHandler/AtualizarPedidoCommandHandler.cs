using System;
using System.Threading.Tasks;
using Domain.Commands;
using Domain.Notifications;
using Domain.Repositories;

namespace Domain.CommandHandler
{
    public class AtualizarPedidoCommandHandler : CommandHandler<PedidoCommand, string>
    {
        private readonly IPedidoCommandRepository _pedidoCommandRepository;
        public AtualizarPedidoCommandHandler( NotificationPool notificationPool, IPedidoCommandRepository pedidoCommandRepository)
        {
            _notificationPool = notificationPool;
            _pedidoCommandRepository = pedidoCommandRepository;
        }
        protected override async Task<string> RunCommand(PedidoCommand command)
        {
    
            this._pedidoCommandRepository.AtualizarPedido(command);

            if (this._pedidoCommandRepository.HasNotifications)
            {
                this._notificationPool.AddNotifications(this._pedidoCommandRepository.Notifications);
                return String.Empty;
            }
            return String.Empty;
        }
    }
}