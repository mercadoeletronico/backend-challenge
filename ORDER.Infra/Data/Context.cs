using Microsoft.EntityFrameworkCore;
using ORDER.Domain.Entities;
using ORDER.Infra.Data.Mapping;
using ORDER.Infra.Data.Seed;

namespace ORDER.Infra.Data
{
    public class Context : DbContext
    {
        public Context()
        { }

        public Context(DbContextOptions<Context> builderOptions) : base(builderOptions)
        { }
        
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<Item> Items { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>().MappingOrder();
            builder.Entity<Item>().MappingItem();
            builder.Entity<Order>().HasData(SeedOrder.OrderSeed());
            builder.Entity<Item>().HasData(SeedItem.ItemSeed());
       
            base.OnModelCreating(builder);

        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
            // optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=myp;Password=batata123;Database=me-project;");
        // }
    }
}