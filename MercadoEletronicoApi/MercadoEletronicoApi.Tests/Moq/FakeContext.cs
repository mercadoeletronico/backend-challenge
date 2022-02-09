using MercadoEletronicoApi.Domain.Entities;
using MercadoEletronicoApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;

namespace MercadoEletronicoApi.Tests.Moq
{
    public static class FakeContext
    {
        private static readonly DbContextOptions<MercadoEletronicoDbContext> ContextOptions = new DbContextOptionsBuilder<MercadoEletronicoDbContext>()
           .UseInMemoryDatabase("MeDbFakeContextInMemory")
           .EnableSensitiveDataLogging()
           .ConfigureWarnings(warnings => warnings.Ignore(InMemoryEventId.TransactionIgnoredWarning))
           .Options;

        public static MercadoEletronicoDbContext GetFakeContext()
        {
            var fakeContext = new MercadoEletronicoDbContext(ContextOptions);

            AddOrder(fakeContext);
            AddItem(fakeContext);

            fakeContext.Database.EnsureCreated();
            fakeContext.Database.BeginTransaction();
            return fakeContext;
        }

        private static void AddOrder(MercadoEletronicoDbContext fakeContext)
        {
            fakeContext.Orders.AddRange(OrderSeed());
            fakeContext.SaveChanges();
        }

        private static void AddItem(MercadoEletronicoDbContext fakeContext)
        {
            fakeContext.Items.AddRange(ItemSeed());
            fakeContext.SaveChanges();
        }

        private static IEnumerable<Order> OrderSeed()
        {
            return new List<Order>()
            {
                new Order
                {
                    Id = 1,
                    OrderCode = "1234",
                    Items = new List<Item>()
                },
                new Order
                {
                    Id = 2,
                    OrderCode = "5678",
                    Items = new List<Item>()
                }
            };
        }

        private static IEnumerable<Item> ItemSeed()
        {
            return new List<Item>()
            {
                new Item
                {
                    Id = 1,
                    Description = "USB Keyboard Logitech",
                    UnitPrice = 90,
                    Quantity = 1,
                    OrderId = 1
                },
                new Item
                {
                    Id = 2,
                    Description = "Mouse Gamer Redragon",
                    UnitPrice = 60,
                    Quantity = 1,
                    OrderId = 1
                },
                new Item
                {
                    Id = 3,
                    Description = "Headset Gamer Pichau",
                    UnitPrice = 280,
                    Quantity = 1,
                    OrderId = 2
                }
            };
        }

    }
}
