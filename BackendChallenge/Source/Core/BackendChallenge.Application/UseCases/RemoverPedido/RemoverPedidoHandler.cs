using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BackendChallenge.Application.Extensions;
using BackendChallenge.Entities;
using BackendChallenge.Ports.Adapters.Database;

using MediatR;

namespace BackendChallenge.Application.UseCases
{
    public class RemoverPedidoHandler : IRequestHandler<RemoverPedido>
    {
        private readonly IDataStoreUnitOfWork _unitOfWork;

        public RemoverPedidoHandler(IDataStoreUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoverPedido request, CancellationToken cancellationToken)
        {
            Order order = _unitOfWork.Orders.Get().FirstOrDefault
                (
                    f => f.Number == request.Pedido
                );

            _unitOfWork.OrderItems.Delete(order.Items);

            _unitOfWork.Orders.Delete(order);

            await _unitOfWork.Commit();

            return await Unit.Task;
        }
    }
}
