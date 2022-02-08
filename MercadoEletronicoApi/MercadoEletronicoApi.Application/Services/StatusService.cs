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
        private readonly IPedidoRepository _pedidoRepository;

        public StatusService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<StatusResponseDTO> AtualizarStatus(StatusRequestDTO statusRequestDTO)
        {
            var pedido = await _pedidoRepository.GetOrderByOrderCodeAsync(statusRequestDTO.PedidoId);

            if (pedido is null)
                return PedidoNaoEncontrado(statusRequestDTO.PedidoId.ToString(), Constantes.InvalidOrderCode);

            if (StatusNaoAprovadoNaRequisicao(statusRequestDTO))
                return CreateStatusResponse(statusRequestDTO.PedidoId, StatusTypes.DisapprovedStatus);

            if (RequisicaoIgualAoPedido(statusRequestDTO, pedido))
                return CreateStatusResponse(statusRequestDTO.PedidoId, StatusTypes.AprovedStatus);

            var statusResponse = CreateStatusResponse(statusRequestDTO.PedidoId);

            RetornarStatus(statusRequestDTO, pedido, statusResponse);

            return statusResponse;
        }

        private StatusResponseDTO PedidoNaoEncontrado(string pedidoId, string status) 
        {
            return new StatusResponseDTO
            {
                PedidoId = pedidoId,
                Status = new List<string>() { status }
            };
        }

        private static bool StatusNaoAprovadoNaRequisicao(StatusRequestDTO request)
        {
            return request.Status!= StatusTypes.AprovedStatus;
        }

        private bool RequisicaoIgualAoPedido(StatusRequestDTO request, Pedido pedido)
        {
            return request.Status.Equals(StatusTypes.AprovedStatus) && 
                pedido.ValorTotal() == request.ValorAprovado && 
                pedido.TotalItens() == request.ItensAprovados;
        }

        private StatusResponseDTO CreateStatusResponse(string pedidoId, string status = "")
        {
            return new StatusResponseDTO
            {
                PedidoId = pedidoId,
                Status = new List<string>() { status }
            };
        }

        private static void RetornarStatus(StatusRequestDTO request, Pedido pedido, StatusResponseDTO status)
        {
            if (request.ValorAprovado < pedido.ValorTotal() && request.Status == StatusTypes.AprovedStatus)
                status.Status.Add(StatusTypes.ApprovedValueLower);

            if (request.ValorAprovado == pedido.ValorTotal() && request.Status == StatusTypes.AprovedStatus)
                status.Status.Add(StatusTypes.AprovedStatus);

            if (request.ValorAprovado > pedido.ValorTotal() && request.Status == StatusTypes.AprovedStatus)
                status.Status.Add(StatusTypes.ApprovedValueGreater);

            if (request.ItensAprovados < pedido.TotalItens() && request.Status == StatusTypes.AprovedStatus)
                status.Status.Add(StatusTypes.ApprovedQuantityLower);

            if (request.ItensAprovados == pedido.TotalItens() && request.Status == StatusTypes.AprovedStatus)
                status.Status.Add(StatusTypes.AprovedStatus);

            if (request.ItensAprovados > pedido.TotalItens() && request.Status == StatusTypes.AprovedStatus)
                status.Status.Add(StatusTypes.ApprovedQuantityGreater);
        }

    }

}
