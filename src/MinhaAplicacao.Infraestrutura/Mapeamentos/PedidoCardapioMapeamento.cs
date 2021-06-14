using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAplicacao.Dominio.Entidades;

namespace MinhaAplicacao.Infraestrutura.Mapeamentos
{
    public class PedidoCardapioMapeamento : IEntityTypeConfiguration<PedidoCardapio>
    {
        public void Configure(EntityTypeBuilder<PedidoCardapio> builder)
        {
            builder.ToTable("Pedidos_Cardapios");

            builder.HasKey(pc => new { pc.PedidoId, pc.CardapioId });

            builder.HasOne(pc => pc.Pedido).WithMany(s => s.PedidoCardapios).HasForeignKey(sc => sc.PedidoId);
            builder.HasOne(pc => pc.Cardapio).WithMany(s => s.PedidoCardapios).HasForeignKey(sc => sc.CardapioId);
        }
    }
}
