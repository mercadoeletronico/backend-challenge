using Core.Helpers;
using Core.Models.Responses.Pedido;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Queries.Pedido
{
    public class GetPedidoQuery : IRequest<Result<IEnumerable<PedidoResponse>>>
    {
    }
}
