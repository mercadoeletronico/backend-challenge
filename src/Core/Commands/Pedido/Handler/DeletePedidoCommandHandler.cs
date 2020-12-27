using System;
using AutoMapper;
using Core.Helpers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Core.Interfaces.Repositories;
using Core.Models.Responses.Pedido;
using System.Collections.Generic;
using System.Linq;

namespace Core.Commands.Pedido.Handler
{
    public class DeletePedidoCommandHandler : IRequestHandler<DeletePedidoCommand, Result<DeletePedidoResponse>>
    {
        #region properties
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        #endregion

        #region constructor
        public DeletePedidoCommandHandler(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }
        #endregion

        #region actions
        public async Task<Result<DeletePedidoResponse>> Handle(DeletePedidoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Result<DeletePedidoResponse>();
                var pedido = await _pedidoRepository.GetByCodigoAsync(request.DeletePedidoRequest.CodigoPedido);

                if (!pedido.Any())
                {
                    result.WithError("Não existe o pedido informado!");
                    return result;
                }

                _pedidoRepository.DeleteAsync(pedido.FirstOrDefault());                
                result.Value = new DeletePedidoResponse(true);
       
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
