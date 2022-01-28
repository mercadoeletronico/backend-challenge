using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ORDER.Domain.Entities;

namespace ORDER.Infra.Data.Mapping
{
    public static class ItemMapping
    {
        public static void MappingItem(this EntityTypeBuilder<Item> entity)
        {
            entity.HasKey(x => x.Id)
                .HasName("PK_ITEM");
            
            entity.ToTable("ITEM");

            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd();
                // .HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            
            // modelBuilder.Entity<Order>(order =>
            // {
                // var orderNumber = order.Property(p => p.OrderNumber);
                // orderNumber.ValueGeneratedOnAdd();
                // only for in-memory
                // if (Database.IsInMemory())
                    // orderNumber.HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            // });

            entity.Property(x => x.Description).IsRequired();
            entity.Property(x => x.UnitPrice).IsRequired();
            entity.Property(x => x.Quantity).IsRequired();

            entity.HasOne(x => x.Order)
                .WithMany(y => y.Items)
                .HasForeignKey(z => z.OrderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ITEM_ODER");
            
        }
    }
}