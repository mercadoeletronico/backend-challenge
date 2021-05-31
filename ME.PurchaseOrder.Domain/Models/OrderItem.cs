using ME.PurchaseOrder.Domain.Models.Base;

namespace ME.PurchaseOrder.Domain.Models
{
    public class OrderItem : Entity
    {
        public OrderItem()
        {
        }

        public long OrderId { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}