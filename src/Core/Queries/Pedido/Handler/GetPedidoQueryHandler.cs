using AutoMapper;
using Core.Helpers;
using Core.Interfaces.Repositories;
using Core.Models.Responses.Pedido;
using Core.Queries.Pedido;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Queries.ParametrizacaoRegra.Handler
{
    public class GetPedidoQueryHandler : IRequestHandler<GetPedidoQuery, Result<IEnumerable<PedidoResponse>>>
    {

        #region properties
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        #endregion

        #region constructor
        public GetPedidoQueryHandler(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }
        #endregion

        #region actions
        public async Task<Result<IEnumerable<PedidoResponse>>> Handle(GetPedidoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Result<IEnumerable<PedidoResponse>>();

                var lista = await _pedidoRepository.GetAllAsync();

                result.Value = lista.Select(p => _mapper.Map<PedidoResponse>(p));

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
