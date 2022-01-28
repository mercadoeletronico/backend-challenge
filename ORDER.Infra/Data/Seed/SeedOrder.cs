using System.Collections.Generic;
using ORDER.Domain.Entities;

namespace ORDER.Infra.Data.Seed
{
    public static class SeedOrder
    {

        public static IEnumerable<Order> OrderSeed()
        {
            return new List<Order>()
            {
                new Order
                {
                    Id = 1,
                    OrderId = "123",
                    Items = new List<Item>()
                },
                new Order
                {
                    Id = 2,
                    OrderId = "123456",
                    Items = new List<Item>()
                }
            };
        }
    }
}