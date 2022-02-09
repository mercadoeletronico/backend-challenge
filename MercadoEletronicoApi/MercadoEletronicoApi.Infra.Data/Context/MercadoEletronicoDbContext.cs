using MercadoEletronicoApi.Domain.Entities;
using MercadoEletronicoApi.Infra.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace MercadoEletronicoApi.Infra.Data.Context
{
    public class MercadoEletronicoDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }

        public MercadoEletronicoDbContext(DbContextOptions<MercadoEletronicoDbContext> options) : base(options)
        {}

        public MercadoEletronicoDbContext()
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new ItemConfiguration());
        }

    }
}
