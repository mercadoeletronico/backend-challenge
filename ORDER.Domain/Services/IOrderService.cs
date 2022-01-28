using System.Collections.Generic;
using ORDER.Domain.Dto;

namespace ORDER.Domain.Services
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