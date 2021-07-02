using System;

namespace backend_challenge_domain_datatypes.Entities
{
    public class EquivalentProduct
        : TransactionalEntityBase
    {
        public Guid SellerProductId { get; set; }
        public Guid CustomerProductId { get; set; }
    }
}
