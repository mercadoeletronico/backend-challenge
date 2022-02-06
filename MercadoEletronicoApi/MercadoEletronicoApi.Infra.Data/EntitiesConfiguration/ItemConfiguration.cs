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
                .Property(i => i.Descricao)
                .HasMaxLength(100)
                .IsRequired();
            
            builder
                .Property(i => i.PrecoUnitario)
                .HasPrecision(10, 2);
            
            builder
                .Property(i => i.Quantidade)
                .IsRequired();

            builder
                .HasOne(p => p.Pedido)
                .WithMany(i => i.Items)
                .HasForeignKey(p => p.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
