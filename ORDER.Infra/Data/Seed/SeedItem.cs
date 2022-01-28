using System.Collections.Generic;
using ORDER.Domain.Entities;

namespace ORDER.Infra.Data.Seed
{
    public static class SeedItem
    {
        public static IEnumerable<Item> ItemSeed()
        {
            return new List<Item>()
            {
                new Item
                {
                    Id = 1,
                    Description = "test",
                    UnitPrice = 5,
                    Quantity = 2,
                    OrderId = 1
                },
                new Item
                {
                    Id = 2,
                    Description = "Item A",
                    UnitPrice = 10,
                    Quantity = 1,
                    OrderId = 2
                },
                new Item
                {
                    Id = 3,
                    Description = "Item B",
                    UnitPrice = 5,
                    Quantity = 2,
                    OrderId = 2
                }
                
            };
        }
    }
}