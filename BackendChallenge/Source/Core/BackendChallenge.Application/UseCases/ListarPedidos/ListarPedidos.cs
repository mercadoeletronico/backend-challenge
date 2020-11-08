using System.Collections.Generic;

using MediatR;

namespace BackendChallenge.Application.UseCases
{
    public class ListarPedidos : IRequest<IEnumerable<PedidoEncontrado>>
    {

    }
}
