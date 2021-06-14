using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAplicacao.Dominio.Entidades;

namespace MinhaAplicacao.Infraestrutura.Mapeamentos
{
    public class PedidoMapeamento : BaseMapeamento<int, Pedido>
    {
        public override void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");

            builder.Property(p => p.Numero).HasMaxLength(80).IsUnicode(false).IsRequired();

            base.Configure(builder);
        }
    }
}
