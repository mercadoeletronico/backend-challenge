using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ORDER.Domain.Entities;

namespace ORDER.Infra.Data.Mapping
{
    public static class OrderMapping
    {
        public static void MappingOrder(this EntityTypeBuilder<Order> entity)
        {
            entity.HasKey(x => x.Id)
                .HasName("PK_ORDER");
            
            entity.ToTable("ORDER");

            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            entity.Property(x => x.OrderId)
                .IsRequired();

        }
    }
}