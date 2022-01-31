using System.Collections.Generic;
using ORDER.Application.Dto;

namespace ORDER.Application.Services.Interfaces
{
    public interface IOrderService
    {
        OrderDto CreateOrder(OrderDto order);
        List<OrderDto> GetOrders();
        OrderDto GetOrderById(string orderId);
        OrderDto DeleteOrder(string orderId);
        OrderDto UpdateOrder(OrderDto order);
    }
}