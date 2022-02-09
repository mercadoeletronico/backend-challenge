using MercadoEletronicoApi.Domain.Entities;
using MercadoEletronicoApi.Infra.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace MercadoEletronicoApi.Infra.Data.Context
{
    public class MercadoEletronicoDbContext : DbContext
    {
        public DbSet<Order> Pedidos { get; set; }
        public DbSet<Item> Itens { get; set; }

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
