using ME.PurchaseOrder.Domain.Commands.Base;

namespace ME.PurchaseOrder.Domain.Commands.OrderBase
{
    public class OrderItemCommand : Command
    {
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}