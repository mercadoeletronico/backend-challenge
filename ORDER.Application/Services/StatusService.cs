using System.Collections.Generic;
using ORDER.Application.Utils;
using ORDER.Domain.Dto;
using ORDER.Domain.Exceptions;
using ORDER.Domain.Repositories;
using ORDER.Domain.Services;

namespace ORDER.Application.Services
{
    public class StatusService : IStatusService
    {
        private readonly IOrderRepository _orderRepository;

        public StatusService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public StatusResponseDto ApprovedStatus(StatusRequestDto request)
        {
            var order = _orderRepository.GetOrderById(request.OrderId);

            NotFoundOrderException.When(order == null);

            if (NotApprovedStatus(request)) return ReturnStatus(request.OrderId, StatusTypes.Reproved);

            var status = CreateStatusResponse(request.OrderId);

            // ReSharper disable once PossibleNullReferenceException
            if (order.ItemsValue() > request.ApprovedValue)
                status.Status.Add(StatusTypes.ApprovedValueLower);

            if (order.ItemsValue() < request.ApprovedValue)
                status.Status.Add(StatusTypes.ApprovedValueGreater);

            if (order.ItemsCount() > request.ApprovedItems)
                status.Status.Add(StatusTypes.ApprovedQtyLower);

            if (order.ItemsCount() < request.ApprovedItems)
                status.Status.Add(StatusTypes.ApprovedQtyGreater);

            if (status.Status.Count == 0)
                status.Status.Add(StatusTypes.Approved);

            return status;
        }

        private static bool NotApprovedStatus(StatusRequestDto request)
        {
            return request.Status.ToUpper() != StatusTypes.Approved;
        }

        private StatusResponseDto CreateStatusResponse(string orderId)
        {
            return new StatusResponseDto
            {
                OrderId = orderId,
                Status = new List<string>()
            };
        }

        private StatusResponseDto ReturnStatus(string orderId, string status)
        {
            return new StatusResponseDto
            {
                OrderId = orderId,
                Status = new List<string>() {status.ToString()}
            };
        }
    }
}