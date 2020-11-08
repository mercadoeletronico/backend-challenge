using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidosME.Domain.PedidoAggregate.Entities;

namespace PedidosME.Data.Mappings
{
    public class PedidoMapping : BaseMapping<Pedido>
    {
        public override void Configure(EntityTypeBuilder<Pedido> builder)
        {
            
            builder.ToTable(name: "TB_PEDIDO");
            builder.HasKey(x => x.Codigo)
                .HasName("CODIGO");

            builder.HasMany(x => x.Itens)
                .WithOne(x => x.Pedido)
                .HasForeignKey(x=> x.CodigoPedido)
                .OnDelete(DeleteBehavior.Cascade);


            base.Configure(builder);
                
        }
    }
}
