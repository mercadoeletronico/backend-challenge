using System.Linq;

using BackendChallenge.Adapters.Database;
using BackendChallenge.Entities;

namespace BackendChallenge.AcceptanceTests.UseCases
{
    public static class DataSeeder
    {
        public static void SeedOrders(this DataStoreContext context)
        {
            if (!context.Orders.Any())
            {
                Order order = new Order
                {
                    Id = -1,
                    Number = "123456",
                    Items = new OrderItem[]
                    {
                        new OrderItem { Id = -1, OrderId = -1, Description = "Item A", UnitPrice= 10, Quantity = 1 },
                        new OrderItem { Id = -2, OrderId = -1, Description = "Item B", UnitPrice= 5, Quantity = 2 }
                    }
                };

                context.Add(order);

                context.SaveChanges();
            }
        }
    }
}
