using System;

namespace backend_challenge_datatypes.Entities
{
    public class TransactionalEntityBase
        : EntityBase
    {
        public bool Deleted { get; set; }

        public void ChargeToInsert() 
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.UtcNow;
            this.UpdatedAt = DateTime.UtcNow;
            this.Deleted = false;
        }
    }
}
