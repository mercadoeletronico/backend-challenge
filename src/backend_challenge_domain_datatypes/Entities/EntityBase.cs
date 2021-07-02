using System;

namespace backend_challenge_domain_datatypes.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }        
    }
}
