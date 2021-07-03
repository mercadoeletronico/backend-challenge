using System;

namespace backend_challenge_domain_datatypes.Entities
{
    public class PriceList
        : TransactionalEntityBase
    {
        public Guid SellerId { get; set; }
        public Guid ProductId { get; set; }
        public decimal UnitaryValue { get; set; }
    }
}
