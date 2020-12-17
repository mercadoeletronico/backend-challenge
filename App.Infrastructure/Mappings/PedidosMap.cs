using App.Domain.Entities;
using App.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Mappings
{
    public class PedidosMap: IEntityTypeConfiguration<Pedido>
    {

        public void Configure(EntityTypeBuilder<Pedido> entity)
        {

            entity.ToTable("me_pedido");
            entity.HasKey(x => x.Id);
            entity.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("INTEGER");

            entity.Property(x => x.CodigoPedido).IsRequired().HasColumnType(Constants.Integer);

        }

    }
}