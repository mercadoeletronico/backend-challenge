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

        public async Task<StatusResponseDTO> UpdateStatus(StatusRequestDTO statusRequestDTO)
        {
            var pedido = await _pedidoRepository.GetOrderByOrderCodeAsync(statusRequestDTO.OrderId);

            if (pedido is null) 
            {
                var response = OrderNotFound(statusRequestDTO.OrderId.ToString(), Constantes.InvalidOrderCode);
                return response;
            }

            if (StatusNotApprovedOnRequest(statusRequestDTO)) 
            {   
                var response = CreateStatusResponse(statusRequestDTO.OrderId, StatusTypes.DisapprovedStatus);
                return response;
            }

            if (StatusRequestEqualsOrder(statusRequestDTO, pedido)) 
            {
                var response = CreateStatusResponse(statusRequestDTO.OrderId, StatusTypes.AprovedStatus);
                return response;
            }
                
            var statusResponse = CreateStatusResponse(statusRequestDTO.OrderId, StatusTypes.AprovedStatus);

            ReturnStatus(statusRequestDTO, pedido, statusResponse);

            return statusResponse;
        }

        private StatusResponseDTO OrderNotFound(string pedidoId, string status) 
        {
            return new StatusResponseDTO
            {
                OrderId = pedidoId,
                Status = new List<string>() { status }
            };
        }

        private static bool StatusNotApprovedOnRequest(StatusRequestDTO request)
        {
            return request.Status!= StatusTypes.AprovedStatus;
        }

        private bool StatusRequestEqualsOrder(StatusRequestDTO request, Order pedido)
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

        private static void ReturnStatus(StatusRequestDTO request, Order pedido, StatusResponseDTO status)
        {
            if (request.ApprovedValue < pedido.GetTotalOrderAmount() && request.Status == StatusTypes.AprovedStatus)
                status.Status.Add(StatusTypes.ApprovedValueLower);

            //if (request.ApprovedValue == pedido.GetTotalOrderAmount() && request.Status == StatusTypes.AprovedStatus)
            //    status.Status.Add(StatusTypes.AprovedStatus);

            if (request.ApprovedValue > pedido.GetTotalOrderAmount() && request.Status == StatusTypes.AprovedStatus)
                status.Status.Add(StatusTypes.ApprovedValueGreater);

            if (request.ApprovedItens < pedido.GetTotalOrderItems() && request.Status == StatusTypes.AprovedStatus)
                status.Status.Add(StatusTypes.ApprovedQuantityLower);

            //if (request.ApprovedItens == pedido.GetTotalOrderItems() && request.Status == StatusTypes.AprovedStatus)
            //    status.Status.Add(StatusTypes.AprovedStatus);

            if (request.ApprovedItens > pedido.GetTotalOrderItems() && request.Status == StatusTypes.AprovedStatus)
                status.Status.Add(StatusTypes.ApprovedQuantityGreater);
        }

    }

}
