using System.Threading.Tasks;
using Domain.Commands;
using Domain.Notifications;
using Domain.Repositories;

namespace Domain.CommandHandler
{
    public class CadastrarPedidoCommandHandler : CommandHandler<PedidoCommand, bool>
    {
        private readonly IPedidoCommandRepository _pedidoCommandRepository;
        public CadastrarPedidoCommandHandler( NotificationPool notificationPool, IPedidoCommandRepository pedidoCommandRepository)
        {
            _notificationPool = notificationPool;
            _pedidoCommandRepository = pedidoCommandRepository;
        }
        protected override async Task<bool> RunCommand(PedidoCommand command)
        {
    
            this._pedidoCommandRepository.CadastrarPedido(command);

            if (this._pedidoCommandRepository.HasNotifications)
            {
                this._notificationPool.AddNotifications(this._pedidoCommandRepository.Notifications);
                return false;
            }
            return true;
        }
    }
}