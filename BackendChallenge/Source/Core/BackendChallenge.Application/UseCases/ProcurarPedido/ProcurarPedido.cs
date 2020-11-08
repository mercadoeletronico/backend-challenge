using MediatR;

namespace BackendChallenge.Application.UseCases
{
    public class ProcurarPedido : IRequest<PedidoEncontrado>
    {
        public string Pedido { get; set; }
    }
}
