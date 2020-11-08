using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BackendChallenge.Application.Extensions;
using BackendChallenge.Entities;
using BackendChallenge.Ports.Adapters.Database;

using MediatR;

namespace BackendChallenge.Application.UseCases
{
    public class AlterarPedidoHandler : IRequestHandler<AlterarPedido>
    {
        private readonly IDataStoreUnitOfWork _unitOfWork;

        public AlterarPedidoHandler(IDataStoreUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AlterarPedido request, CancellationToken cancellationToken)
        {
            Order destino = _unitOfWork.Orders.Get().FirstOrDefault(f => f.Number == request.Pedido);

            if (destino != null)
            {
                Order origem = AlterarPedido.ConverTo(request);

                destino.Items.Clear();

                foreach (var item in origem.Items)
                {
                    destino.Items.Add(item);
                }

                _unitOfWork.Orders.Update(destino);

                await _unitOfWork.Commit();

                return await Unit.Task;
            }

            throw new KeyNotFoundException("Pedido não encontrado.");
        }
    }
}
