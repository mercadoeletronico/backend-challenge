using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAplicacao.Dominio.Entidades;
using System;

namespace MinhaAplicacao.Infraestrutura.Mapeamentos
{
    public abstract class BaseMapeamento<TId, TEntidade> : IEntityTypeConfiguration<TEntidade>
        where TId : IEquatable<TId>
        where TEntidade : EntidadeBase<TId>
    {
        public virtual void Configure(EntityTypeBuilder<TEntidade> builder)
        {
            builder.Property(p => p.DataHoraCadastro).IsRequired().HasColumnType("datetime");
            builder.Property(p => p.DataHoraModificado).HasColumnType("datetime");
        }
    }
}
