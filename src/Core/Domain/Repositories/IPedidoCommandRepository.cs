using Domain.Commands;
using Domain.Notifications;

namespace Domain.Repositories
{
    public interface IPedidoCommandRepository : INotifiable
    {
         void CadastrarPedido(PedidoCommand command);
         void AtualizarPedido(PedidoCommand command);
         
    }
}