using ME.PurchaseOrder.Domain.Enums;
using ME.PurchaseOrder.Domain.Extensions;
using ME.PurchaseOrder.Domain.Models.Base;
using System.Collections.Generic;
using System.Linq;

namespace ME.PurchaseOrder.Domain.Models
{
    public class Order : Entity
    {
        public Order()
        {
        }

        public string NumberOrder { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }

        public List<string> GetOrderStatus(OrderStatus approvedStatus, int approvedItems, decimal approvedPrice)
        {
            if (approvedStatus.Equals(OrderStatus.Disapproved))
                return new List<string>() { ErrorCode.Disapproved.GetDescription() };

            var totalItems = Items?.Sum(x => x.Quantity) ?? 0;
            var totalPrice = Items?.Sum(x => x.UnitPrice * x.Quantity) ?? 0;
            var status = new List<string>();

            if (totalPrice != approvedPrice)
                status.Add((totalPrice > approvedPrice ? ErrorCode.LowerPriceApproved : ErrorCode.GreaterPriceApproved).GetDescription());
            if (totalItems != approvedItems)
                status.Add((totalItems > approvedItems ? ErrorCode.LowerQuantityApproved : ErrorCode.GreaterQuantityApproved).GetDescription());

            return status.Any() ? status : new List<string> { ErrorCode.Approved.GetDescription() };
        }
    }
}