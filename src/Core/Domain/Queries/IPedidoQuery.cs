using System.Collections.Generic;
using Domain.Entities;
using Domain.Notifications;

namespace Domain.Queries
{
    public interface IPedidoQuery : INotifiable
    {
         IEnumerable<Pedido> ListarPedido();
         Pedido ListarPedidoByID(string idPedido);
         void RemoverPedido(string numeroPedido);
         StatusPedido VerificarStatusPedido(string status, int itensAprovados, double valorAprovado, string pedido);
    }
}