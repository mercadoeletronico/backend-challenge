using System.Collections.Generic;
using Domain.Entities;
using Domain.Notifications;

namespace Domain.Repositories
{
    public interface IPedidoQueryRepository : INotifiable
    {
        IEnumerable<Pedido> ListarPedido();
        void RemoverPedido(string numeroPedido);
        Pedido ListarPedidoByID(string idPedido);
    }
}