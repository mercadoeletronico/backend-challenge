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
    public class UpdatePedidoCommandHandler : IRequestHandler<UpdatePedidoCommand, Result<PedidoResponse>>
    {
        #region properties
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        #endregion

        #region constructor
        public UpdatePedidoCommandHandler(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }
        #endregion

        #region actions
        public async Task<Result<Models.Responses.Pedido.PedidoResponse>> Handle(UpdatePedidoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Result<Models.Responses.Pedido.PedidoResponse>();                    
                var pedido = _mapper.Map<Core.Entities.Pedido.Pedido>(request.SavePedidoRequest);
                var pedidoExistente = await _pedidoRepository.GetByCodigoAsync(pedido.Codigo);

                IEnumerable<Core.Entities.Pedido.Pedido> pedidoReturn = new List<Core.Entities.Pedido.Pedido>();
                if (!pedidoExistente.Any())
                {
                    result.WithError("Não existe o pedido informado!");
                    return result;
                }
              
                pedidoReturn = await _pedidoRepository.UpdateAsync(pedido);                     
                result.Value = _mapper.Map<PedidoResponse>(pedidoReturn.First());

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
