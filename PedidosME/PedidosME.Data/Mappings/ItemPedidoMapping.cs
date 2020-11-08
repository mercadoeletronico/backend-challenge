using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidosME.Domain.PedidoAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosME.Data.Mappings
{
    public class ItemPedidoMapping : BaseMapping<ItemPedido>
    {
        public override void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            base.Configure(builder);

            builder.ToTable(name: "TB_ITEM_PEDIDO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("ID");
            builder.Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(10);

            builder.Property(x => x.PrecoUnitario)
                .HasColumnName("PRECO_UNITARIO")
                .HasColumnType("decimal(5,2)");
            
            builder.Property(x=> x.Quantidade)
                .HasColumnName("QUANTIDADE")
                .HasColumnType("decimal(5,2)");

            builder.HasOne(x => x.Pedido)
                .WithMany(x => x.Itens)
                .HasForeignKey(x => x.CodigoPedido);


        }
    }
}
