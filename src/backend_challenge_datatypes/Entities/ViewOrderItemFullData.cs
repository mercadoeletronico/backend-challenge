using System;

namespace backend_challenge_datatypes.Entities
{
    public class ViewOrderItemFullData
    {
        public Guid Id { get; set; }
        public string ProductReferenceCode { get; set; }
        public string ProductDescription { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitaryValue { get; set; }
    }
}
