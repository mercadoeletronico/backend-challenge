using System;

namespace backend_challenge_datatypes.Entities
{
    public class OrderItemApproval
        : TransactionalEntityBase
    {
        public Guid OrderItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitaryValue { get; set; }
    }
}
