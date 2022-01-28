using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ORDER.Domain.Entities;
using ORDER.Domain.Repositories;
using ORDER.Infra.Data;

namespace ORDER.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository(Context context)
        {
            _context = context;
        }

        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);

            _context.SaveChanges();
        }

        public List<Order> GetOrders()
        {
            return _context.Orders
                .Include(x => x.Items)
                .ToList();
        }

        public Order GetOrderById(string orderId)
        {
            return _context.Orders
                .Include(x => x.Items)
                .FirstOrDefault(x => x.OrderId == orderId);
        }

        public int DeleteOrder(Order order)
        {
            _context.Remove(order);
            return _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}