using ME.PurchaseOrder.Domain.Models;
using ME.PurchaseOrder.Domain.Repositories.Base;
using ME.PurchaseOrder.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ME.PurchaseOrder.Infra.Repositories.Base
{
    public class BaseContext : DbContext, IUnitOfWork
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItens { get; set; }

        public async Task<bool> Commit()
        {
            //TODO: Include EventSourcing
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}