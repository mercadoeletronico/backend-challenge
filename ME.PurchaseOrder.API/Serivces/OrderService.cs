using AutoMapper;
using ME.PurchaseOrder.API.Interfaces;
using ME.PurchaseOrder.API.Requests;
using ME.PurchaseOrder.API.Responses;
using ME.PurchaseOrder.Domain.Commands;
using ME.PurchaseOrder.Domain.Enums;
using ME.PurchaseOrder.Domain.Extensions;
using ME.PurchaseOrder.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ME.PurchaseOrder.API.Serivces
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IMapper mapper, IMediator mediator, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _orderRepository = orderRepository;
        }

        public async Task<OrderResponse> GetOrderByCodeAsync(string pedido)
        {
            if (string.IsNullOrWhiteSpace(pedido))
                return new OrderResponse(StatusCodes.Status400BadRequest);

            var entity = await _orderRepository.GetOrderByCode(pedido);

            if (entity is null)
                return new OrderResponse(StatusCodes.Status400BadRequest) { Status = new List<string> { ErrorCode.NumberCodeOrderInvalid.GetDescription() } };

            return _mapper.Map<OrderResponse>(entity);
        }

        public async Task<OrderResponse> GetOrderByIdAsync(int id)
        {
            if (id <= 0)
                return new OrderResponse(StatusCodes.Status400BadRequest);

            var entity = await _orderRepository.Find(id);

            return _mapper.Map<OrderResponse>(entity);
        }

        public async Task<BaseListResponse<OrderSummaryResponse>> GetAll()
        {
            var entities = await _orderRepository.Get();

            return _mapper.Map<BaseListResponse<OrderSummaryResponse>>(entities);
        }

        public async Task<BaseResponse> Create(OrderRequest request)
        {
            var command = _mapper.Map<CreateOrderCommand>(request);
            var valid = await _mediator.Send(command);

            if (!valid.IsValid)
                return _mapper.Map<BaseResponse>(valid.Errors);

            return new BaseResponse(StatusCodes.Status201Created);
        }

        public async Task<BaseResponse> Update(OrderRequest request)
        {
            var command = _mapper.Map<UpdateOrderCommand>(request);

            var valid = await _mediator.Send(command);

            if (!valid.IsValid)
                return _mapper.Map<BaseResponse>(valid.Errors);

            return new BaseResponse(StatusCodes.Status204NoContent);
        }

        public async Task<BaseResponse> Delete(string pedido)
        {
            var command = new DeleteOrderCommand(pedido);

            var valid = await _mediator.Send(command);

            if (!valid.IsValid)
                return _mapper.Map<BaseResponse>(valid.Errors);

            return new BaseResponse(StatusCodes.Status204NoContent);
        }

        public async Task<OrderStatusResponse> UpdateStatusOfOrder(UpdateOrderStatusRequest request)
        {
            var command = _mapper.Map<UpdateOrderStatusCommand>(request);

            var valid = await _mediator.Send(command);

            if (!valid.IsValid)
                return _mapper.Map<OrderStatusResponse>(valid.Errors);

            var order = await _orderRepository.GetOrderByCode(request.Pedido);

            var status = order.GetOrderStatus(command.Status, request.ItensAprovados, request.ValorAprovado);

            return new OrderStatusResponse(request.Pedido, status);
        }
    }
}