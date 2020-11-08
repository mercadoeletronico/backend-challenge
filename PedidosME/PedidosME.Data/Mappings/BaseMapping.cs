using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidosME.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosME.Data.Mappings
{
    public abstract class BaseMapping<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Ignore(x => x.Id);
            builder.Ignore(x => x.IsValid);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
