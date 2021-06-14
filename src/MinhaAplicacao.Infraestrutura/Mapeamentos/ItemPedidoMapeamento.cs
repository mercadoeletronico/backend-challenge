using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAplicacao.Dominio.Entidades;

namespace MinhaAplicacao.Infraestrutura.Mapeamentos
{
    public class ItemItemPedidoMapeamento : BaseMapeamento<int, ItemPedido>
    {
        public override void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("ItemPedidos");

            builder.Property(ip => ip.Descricao).HasMaxLength(80).IsUnicode(false).IsRequired();
            builder.Property(ip => ip.PrecoUnitario).HasPrecision(10, 2).IsRequired();
            builder.Property(ip => ip.Quantidade).IsRequired();

            builder.HasOne(ip => ip.Pedido).WithMany(p => p.ItensPedidos).HasForeignKey(ip => ip.PedidoId).IsRequired();

            base.Configure(builder);
        }
    }
}