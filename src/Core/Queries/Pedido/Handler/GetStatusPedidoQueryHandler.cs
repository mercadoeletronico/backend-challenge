using AutoMapper;
using Core.Enums;
using Core.Helpers;
using Core.Interfaces.Repositories;
using Core.Models.Requests.Pedido;
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
    public class GetStatusPedidoQueryHandler : IRequestHandler<GetStatusPedidoQuery, Result<StatusPedidoResponse>>
    {

        #region properties
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        private double _valoTotal;
        private int _quantidadeTotal;
        #endregion

        #region constructor
        public GetStatusPedidoQueryHandler(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
            _valoTotal = 0;
            _quantidadeTotal = 0;
        }
        #endregion

        #region actions
        public async Task<Result<StatusPedidoResponse>> Handle(GetStatusPedidoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                StatusPedidoResponse response = new StatusPedidoResponse(request.StatusPedidoRequest.Pedido);
                var result = new Result<StatusPedidoResponse>();

                // rules - pedido não for localizado no banco de dados.
                var lista = await ValidateCodigoInvalido(request.StatusPedidoRequest, response);
                if (response.Status.Any())
                {
                    result.Value = response;
                    return result;
                }

                //rules - status reprovado
                string reprovado = EnumHelper.ObterDescricaoEnum(EnumStatusPedido.REPROVADO);
                if (reprovado.Equals(request.StatusPedidoRequest.Status))
                    ValidatePedidosReprovados(response);

                var pedido = lista.FirstOrDefault();
                _valoTotal = pedido.Itens.Sum(x => x.Valor);
                _quantidadeTotal = pedido.Itens.Sum(x => x.Quantidade);

                //rules - status aprovado
                string aprovado = EnumHelper.ObterDescricaoEnum(EnumStatusPedido.APROVADO);
                if (aprovado.Equals(request.StatusPedidoRequest.Status))
                    ValidatePedidosAprovados(request.StatusPedidoRequest, response);

                result.Value = response;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region private rules
        private void ValidatePedidosAprovados(StatusPedidoRequest request, StatusPedidoResponse response)
        {
            if (request.ItensAprovados == _quantidadeTotal && request.ValorAprovado == _valoTotal)
                response.Status.Add(EnumHelper.ObterDescricaoEnum(EnumStatusPedido.APROVADO));


            if (request.ValorAprovado < _valoTotal)
                response.Status.Add(EnumHelper.ObterDescricaoEnum(EnumStatusPedido.APROVADO_VALOR_A_MENOR));

            if (request.ItensAprovados < _quantidadeTotal)
                response.Status.Add(EnumHelper.ObterDescricaoEnum(EnumStatusPedido.APROVADO_QTD_A_MENOR));

            if (request.ValorAprovado > _valoTotal)
                response.Status.Add(EnumHelper.ObterDescricaoEnum(EnumStatusPedido.APROVADO_VALOR_A_MAIOR));

            if (request.ItensAprovados > _quantidadeTotal)
                response.Status.Add(EnumHelper.ObterDescricaoEnum(EnumStatusPedido.APROVADO_QTD_A_MAIOR));



        }
        private void ValidatePedidosReprovados(StatusPedidoResponse response)
        {
            response.Status.Add(EnumHelper.ObterDescricaoEnum(EnumStatusPedido.REPROVADO));
        }

        private async Task<IEnumerable<Core.Entities.Pedido.Pedido>> ValidateCodigoInvalido(StatusPedidoRequest request, StatusPedidoResponse response)
        {

            bool success = Int64.TryParse(request.Pedido, out long number);
            if (!success)
            {
                response.Status.Add(EnumHelper.ObterDescricaoEnum(EnumStatusPedido.CODIGO_PEDIDO_INVALIDO));
                return null;
            }

            var pedidos = await _pedidoRepository.GetByCodigoAsync(request.Pedido);
            if (!pedidos.Any())
            {
                response.Status.Add(EnumHelper.ObterDescricaoEnum(EnumStatusPedido.CODIGO_PEDIDO_INVALIDO));
                return null;
            }
            return pedidos;
        }

        #endregion
    }
}
