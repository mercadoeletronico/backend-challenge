using App.Domain.Entities;
using App.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Mappings
{
    public class ItensPedidosMap : IEntityTypeConfiguration<ItensPedido>
    {
        public void Configure(EntityTypeBuilder<ItensPedido> entity)
        {
            entity.ToTable("me_itenspedido");
            entity.HasKey(x => x.Id);
            
            entity.Property(x => x.Descricao).IsRequired().HasMaxLength(150).HasColumnType(Constants.Varchar);
            entity.Property(x => x.PrecoUnitario).IsRequired().HasColumnType(Constants.Decimal);
            entity.Property(x => x.Qtd).IsRequired().HasColumnType(Constants.Decimal);

        }

    }
}