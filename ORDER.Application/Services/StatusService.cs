using ORDER.Domain.Dto;
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
            throw new System.NotImplementedException();
        }
    }
}