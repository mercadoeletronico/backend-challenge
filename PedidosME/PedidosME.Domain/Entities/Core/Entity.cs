using FluentValidation;
using FluentValidation.Results;
using System;

namespace PedidosME.Domain.Entities.Core
{
    public abstract class Entity
    {
        
        public Guid Id { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        
        }
        public abstract bool IsValid { get; }
        public abstract ValidationResult ValidationResult { get; }
        
        

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj))  return true;
            if (!(obj is Entity entity)) return false;
            if (GetType() != entity.GetType())  return false;
            return Id == entity.Id;

        }

        public override int GetHashCode() => Id.GetHashCode();
        
    }
}
