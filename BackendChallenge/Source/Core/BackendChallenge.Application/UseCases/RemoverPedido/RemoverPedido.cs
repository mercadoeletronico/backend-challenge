using MediatR;

namespace BackendChallenge.Application.UseCases
{
    public class RemoverPedido : IRequest
    {
        public string Pedido { get; set; }
    }
}
