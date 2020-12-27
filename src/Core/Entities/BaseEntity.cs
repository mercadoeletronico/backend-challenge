using System;

namespace Core.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public bool Deletado { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
