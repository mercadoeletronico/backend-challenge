using System;

namespace backend_challenge_datatypes.Entities
{
    public class Email
        : TransactionalEntityBase
    {
        public Guid PersonId { get; set; }
        public string Address { get; set; }
    }
}
