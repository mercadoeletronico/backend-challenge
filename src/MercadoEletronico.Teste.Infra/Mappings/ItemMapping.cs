using MercadoEletronico.Teste.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MercadoEletronico.Teste.Infra.Mappings
{
    public class ItemMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
               .IsRequired()
               .HasColumnType("varchar(200)");

            builder.Property(p => p.PrecoUnitario)
               .IsRequired()
               .HasColumnType("decimal(15,2)");

            builder.Property(p => p.Quantidade)
              .IsRequired()
              .HasColumnType("int");

            builder.ToTable("Itens");
        }
    }
}