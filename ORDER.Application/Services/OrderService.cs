using System;
using System.Collections.Generic;
using AutoMapper;
using ORDER.Application.Dto;
using ORDER.Application.Services.Interfaces;
using ORDER.Domain.Entities;
using ORDER.Domain.Exceptions;
using ORDER.Domain.Exceptions.Handel.ZendeskModule.Exceptions;
using ORDER.Domain.Repositories;

namespace ORDER.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repository;

        public OrderService(IMapper mapper, IOrderRepository orderRepository)
        {
            _repository = orderRepository;
            _mapper = mapper;
        }

        public OrderDto CreateOrder(OrderDto order)
        {
            var mapped = _mapper.Map<Order>(order);

            _repository.CreateOrder(mapped);
            Console.WriteLine(mapped.Id);

            return _mapper.Map<OrderDto>(mapped);
        }

        public List<OrderDto> GetOrders()
        {
            var orders = _repository.GetOrders();
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public OrderDto GetOrderById(string orderId)
        {
            var order = _repository.GetOrderById(orderId);

            NotFoundOrderException.When(order == null);

            return _mapper.Map<OrderDto>(order);
        }

        public OrderDto DeleteOrder(string orderId)
        {
            var order = _repository.GetOrderById(orderId);

            NotFoundOrderException.When(order == null);

            var deleted = _repository.DeleteOrder(order);

            NotDeletedOrderException.When(deleted < 1);

            return _mapper.Map<OrderDto>(deleted);
        }

        public OrderDto UpdateOrder(OrderDto order)
        {
            var toUpdate = _repository.GetOrderById(order.OrderId);

            NotFoundOrderException.When(toUpdate == null);

            // ReSharper disable once PossibleNullReferenceException
            toUpdate.Items = _mapper.Map<List<Item>>(order.Items);

            _repository.UpdateOrder(toUpdate);

            return _mapper.Map<OrderDto>(toUpdate);
        }
    }
}