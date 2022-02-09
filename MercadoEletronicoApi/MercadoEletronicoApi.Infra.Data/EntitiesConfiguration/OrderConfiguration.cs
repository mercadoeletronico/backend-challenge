using MercadoEletronicoApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MercadoEletronicoApi.Infra.Data.EntitiesConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.OrderCode)
                .IsRequired();
        }

    }
}
