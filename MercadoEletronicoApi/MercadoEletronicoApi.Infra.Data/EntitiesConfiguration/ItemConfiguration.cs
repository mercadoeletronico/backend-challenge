using MercadoEletronicoApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MercadoEletronicoApi.Infra.Data.EntitiesConfiguration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder
                .Property(i => i.Description)
                .HasMaxLength(100)
                .IsRequired();
            
            builder
                .Property(i => i.UnitPrice)
                .HasPrecision(10, 2);
            
            builder
                .Property(i => i.Quantity)
                .IsRequired();

            builder
                .HasOne(p => p.Order)
                .WithMany(i => i.Items)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
