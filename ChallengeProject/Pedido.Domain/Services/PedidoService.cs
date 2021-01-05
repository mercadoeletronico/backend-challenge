using Pedido.Domain.Notifications;
using Pedido.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pedido.Domain.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly NotificationContext _notificationContext;

        public PedidoService(IPedidoRepository pedidoRepository, NotificationContext notificationContext)
        {
            _pedidoRepository = pedidoRepository;
            _notificationContext = notificationContext;
        }
        public Boolean AddAsync(Models.Pedido pedido)
        {
            if (!pedido.IsValido()) { }
                _notificationContext.AddNotifications(pedido.ValidationResult);

            return _pedidoRepository.AddAsync(pedido);
        }

        public async Task<Models.Pedido> FindAsync(string numeroPedido)
        {
            return await _pedidoRepository.FindByAsync(numeroPedido);
        }

        public async Task<IEnumerable<Models.Pedido>> ListAsync()
        {
            return await _pedidoRepository.ListAsync();
        }

        public Boolean Remove(Models.Pedido pedido)
        {
            if (!pedido.IsValido()) { }
                _notificationContext.AddNotifications(pedido.ValidationResult);

            return _pedidoRepository.Remove(pedido);
        }

        public Boolean Update(Models.Pedido pedido)
        {
            if (!pedido.IsValido()) { }
                _notificationContext.AddNotifications(pedido.ValidationResult);

            return _pedidoRepository.Update(pedido);
        }
    }
}
