using MediatR;
using PedidosME.Domain.DTOs;
using PedidosME.Domain.Services;
using System.Threading;
using System.Threading.Tasks;

namespace PedidosME.Domain.Handlers
{
    public class DefinirStatusPedidoHandler : IRequestHandler<AtualizarStatusDTO, StatusPedidoDTO>
    {
        private readonly IPedidoServices pedidoServices;

        public DefinirStatusPedidoHandler(IPedidoServices pedidoServices)
        {
            this.pedidoServices = pedidoServices;
        }
        public async Task<StatusPedidoDTO> Handle(AtualizarStatusDTO request, CancellationToken cancellationToken)
        {
            return await pedidoServices.DefinirStatusPedido(request, cancellationToken);
        }
    }
}
