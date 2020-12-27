using Core.Helpers;
using Core.Models.Requests.Pedido;
using Core.Models.Responses.Pedido;
using MediatR;
using System.Collections.Generic;

namespace Core.Commands.Pedido
{
    public class UpdatePedidoCommand : IRequest<Result<PedidoResponse>>
    {
        public SavePedidoRequest SavePedidoRequest { get; set; }

        public UpdatePedidoCommand(SavePedidoRequest savePedidoRequest)
        {
            SavePedidoRequest = savePedidoRequest;
        }
    }
}