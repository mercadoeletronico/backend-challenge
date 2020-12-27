using Core.Helpers;
using Core.Models.Requests.Pedido;
using Core.Models.Responses.Pedido;
using MediatR;
using System.Collections.Generic;

namespace Core.Commands.Pedido
{
    public class DeletePedidoCommand : IRequest<Result<DeletePedidoResponse>>
    {
        public DeletePedidoRequest DeletePedidoRequest { get; set; }

        public DeletePedidoCommand(DeletePedidoRequest deletePedidoRequest)
        {
            DeletePedidoRequest = deletePedidoRequest;
        }
    }
}