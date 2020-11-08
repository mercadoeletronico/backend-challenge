using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BackendChallenge.Ports.Adapters.Database;

using MediatR;

namespace BackendChallenge.Application.UseCases
{
    public class ProcurarPedidoHandler : IRequestHandler<ProcurarPedido, PedidoEncontrado>
    {
        private readonly IDataStoreUnitOfWork _unitOfWork;

        public ProcurarPedidoHandler(IDataStoreUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PedidoEncontrado> Handle(ProcurarPedido request, CancellationToken cancellationToken)
        {
            await Unit.Task;

            var order = _unitOfWork.Orders.Get().FirstOrDefault
            (
                f => f.Number == request.Pedido
            );

            return PedidoEncontrado.ConvertFrom(order);
        }
    }
}
