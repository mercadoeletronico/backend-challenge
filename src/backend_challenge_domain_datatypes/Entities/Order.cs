using System;

namespace backend_challenge_domain_datatypes.Entities
{
    public class Order
        : TransactionalEntityBase
    {        
        public string Number { get; set; }
        public Guid CustomerId { get; set; }
        public Guid SellerId { get; set; }
    }
}
