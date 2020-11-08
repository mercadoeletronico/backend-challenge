using System.Threading;
using System.Threading.Tasks;

using BackendChallenge.Entities;
using BackendChallenge.Ports.Adapters.Database;

using MediatR;

namespace BackendChallenge.Application.UseCases
{
    public class AdicionarPedidoHandler : IRequestHandler<AdicionarPedido>
    {
        private readonly IDataStoreUnitOfWork _unitOfWork;

        public AdicionarPedidoHandler(IDataStoreUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AdicionarPedido request, CancellationToken cancellationToken)
        {
            Order order = AdicionarPedido.ConvertTo(request);

            _unitOfWork.Orders.Insert(order);

            await _unitOfWork.Commit();

            return await Unit.Task;
        }
    }
}
