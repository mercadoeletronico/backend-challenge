using ME.PurchaseOrder.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ME.PurchaseOrder.Infra.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.NumberOrder);
            builder.HasMany(x => x.Items).WithOne()
                .HasForeignKey(x => x.OrderId);
        }
    }
}