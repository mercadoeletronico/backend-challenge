using System.Collections.Generic;
using ORDER.Domain.Entities;

namespace ORDER.Domain.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        List<Order> GetOrders();
        Order GetOrderById(string orderId);
        int DeleteOrder(Order order);
        void UpdateOrder(Order orderDb);
    }
}