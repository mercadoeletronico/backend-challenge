using Core.Helpers;
using Core.Models.Requests.Pedido;
using Core.Models.Responses.Pedido;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Queries.Pedido
{
    public class GetStatusPedidoQuery : IRequest<Result<StatusPedidoResponse>>
    {
        public StatusPedidoRequest StatusPedidoRequest { get; set; }

        public GetStatusPedidoQuery(StatusPedidoRequest statusPedidoRequest)
        {
            StatusPedidoRequest = statusPedidoRequest;
        }
    }
}
