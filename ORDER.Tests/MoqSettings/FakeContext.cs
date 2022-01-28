using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ORDER.Infra.Data;
using ORDER.Infra.Data.Seed;

namespace ORDER.Tests.MoqSettings
{
    public static class FakeContext
    {
        private static readonly DbContextOptions<Context> ContextOptions = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        public static Context GetFakeContext()
        {
            var fakeContext = new Context(ContextOptions);

            # region Seed

            AddItem(fakeContext);
            AddOrder(fakeContext);

            # endregion

            fakeContext.Database.EnsureCreated();
            fakeContext.Database.BeginTransaction();
            return fakeContext;
        }

        private static void AddItem(Context fakeContext)
        {
            fakeContext.Items.AddRange(SeedItem.ItemSeed());
            fakeContext.SaveChanges();
        }

        private static void AddOrder(Context fakeContext)
        {
            fakeContext.Orders.AddRange(SeedOrder.OrderSeed());
            fakeContext.SaveChanges();
        }
    }
}