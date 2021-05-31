using ME.PurchaseOrder.Domain.Commands.Base;
using System.Collections.Generic;

namespace ME.PurchaseOrder.Domain.Commands.OrderBase
{
    public class OrderCommand : Command
    {
        public OrderCommand() : base()
        {
        }

        public string NumberOrder { get; set; }
        public IEnumerable<OrderItemCommand> Items { get; set; }
    }
}