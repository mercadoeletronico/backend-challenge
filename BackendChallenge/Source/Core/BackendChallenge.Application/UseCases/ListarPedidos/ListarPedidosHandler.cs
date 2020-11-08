using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BackendChallenge.Application.Extensions;
using BackendChallenge.Ports.Adapters.Database;

using MediatR;

namespace BackendChallenge.Application.UseCases
{
    public class ListarPedidosHandler : IRequestHandler<ListarPedidos, IEnumerable<PedidoEncontrado>>
    {
        private readonly IDataStoreUnitOfWork _unitOfWork;

        public ListarPedidosHandler(IDataStoreUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PedidoEncontrado>> Handle(ListarPedidos request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                return _unitOfWork.Orders.Get()
                                         .Select(s => PedidoEncontrado.ConvertFrom(s))
                                         .ToList();
            });
        }
    }
}
