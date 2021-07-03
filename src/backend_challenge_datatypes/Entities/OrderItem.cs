using System;

namespace backend_challenge_datatypes.Entities
{
    public class OrderItem
        : TransactionalEntityBase
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitaryValue { get; set; }
    }
}