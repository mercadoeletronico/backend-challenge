using System;

namespace backend_challenge_domain_datatypes.Entities
{
    public class Customer
        : TransactionalEntityBase
    {
        public Guid PersonId { get; set; }
        public string Code { get; set; }
    }
}
