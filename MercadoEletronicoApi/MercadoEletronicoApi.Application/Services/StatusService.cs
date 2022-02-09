using MercadoEletronicoApi.Application.DTOs;
using MercadoEletronicoApi.Application.Interfaces;
using MercadoEletronicoApi.Application.Utils;
using MercadoEletronicoApi.Domain.Entities;
using MercadoEletronicoApi.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Application.Services
{
    public class StatusService : IStatusService
    {
        private readonly IOrderRepository _pedidoRepository;

        public StatusService(IOrderRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<StatusResponseDTO> AtualizarStatus(StatusRequestDTO statusRequestDTO)
        {
            var pedido = await _pedidoRepository.GetOrderByOrderCodeAsync(statusRequestDTO.OrderId);

            if (pedido is null)
                return PedidoNaoEncontrado(statusRequestDTO.OrderId.ToString(), Constantes.InvalidOrderCode);

            if (StatusNaoAprovadoNaRequisicao(statusRequestDTO))
                return CreateStatusResponse(statusRequestDTO.OrderId, StatusTypes.DisapprovedStatus);

            if (RequisicaoIgualAoPedido(statusRequestDTO, pedido))
                return CreateStatusResponse(statusRequestDTO.OrderId, StatusTypes.AprovedStatus);

            var statusResponse = CreateStatusResponse(statusRequestDTO.OrderId);

            RetornarStatus(statusRequestDTO, pedido, statusResponse);

            return statusResponse;
        }

        private StatusResponseDTO PedidoNaoEncontrado(string pedidoId, string status) 
        {
            return new StatusResponseDTO
            {
                OrderId = pedidoId,
                Status = new List<string>() { status }
            };
        }

        private static bool StatusNaoAprovadoNaRequisicao(StatusRequestDTO request)
        {
            return request.Status!= StatusTypes.AprovedStatus;
        }

        private bool RequisicaoIgualAoPedido(StatusRequestDTO request, Order pedido)
        {
            return request.Status.Equals(StatusTypes.AprovedStatus) && 
                pedido.GetTotalOrderAmount() == request.ApprovedValue && 
                pedido.GetTotalOrderItems() == request.ApprovedItens;
        }

        private StatusResponseDTO CreateStatusResponse(string pedidoId, string status = "")
        {
            return new StatusResponseDTO
            {
                OrderId = pedidoId,
                Status = new List<string>() { status }
            };
        }

        private static void RetornarStatus(StatusRequestDTO request, Order pedido, StatusResponseDTO status)
        {
            if (request.ApprovedValue < pedido.GetTotalOrderAmount() && request.Status == StatusTypes.AprovedStatus)
                status.Status.Add(StatusTypes.ApprovedValueLower);

            if (request.ApprovedValue == pedido.GetTotalOrderAmount() && request.Status == StatusTypes.AprovedStatus)
                status.Status.Add(StatusTypes.AprovedStatus);

            if (request.ApprovedValue > pedido.GetTotalOrderAmount() && request.Status == StatusTypes.AprovedStatus)
                status.Status.Add(StatusTypes.ApprovedValueGreater);

            if (request.ApprovedItens < pedido.GetTotalOrderItems() && request.Status == StatusTypes.AprovedStatus)
                status.Status.Add(StatusTypes.ApprovedQuantityLower);

            if (request.ApprovedItens == pedido.GetTotalOrderItems() && request.Status == StatusTypes.AprovedStatus)
                status.Status.Add(StatusTypes.AprovedStatus);

            if (request.ApprovedItens > pedido.GetTotalOrderItems() && request.Status == StatusTypes.AprovedStatus)
                status.Status.Add(StatusTypes.ApprovedQuantityGreater);
        }

    }

}
