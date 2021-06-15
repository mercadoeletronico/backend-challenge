using MercadoEletronico.Teste.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MercadoEletronico.Teste.Infra.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(c => c.Itens)
               .WithOne(d => d.Pedido)
               .HasForeignKey(d => d.PedidoId);

            builder.ToTable("Pedidos");
        }
    }
}