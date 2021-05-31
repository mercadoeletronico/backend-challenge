using ME.PurchaseOrder.Domain.Enums;
using ME.PurchaseOrder.Domain.Extensions;
using ME.PurchaseOrder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ME.PurchaseOrder.Test.Models
{
    public class OrderTest
    {
        private readonly Order _order;

        public OrderTest()
        {
            _order = new Order
            {
                NumberOrder = "123456",
                Items = new List<OrderItem>
                {
                    new OrderItem { Description = "Item A", Quantity = 1, UnitPrice = 10 },
                    new OrderItem { Description = "Item B", Quantity = 2, UnitPrice = 5 }
                }
            };
        }

        [Theory]
        [InlineData(OrderStatus.Approved, 3, 20, ErrorCode.Approved)]
        [InlineData(OrderStatus.Approved, 3, 10, ErrorCode.LowerPriceApproved)]
        [InlineData(OrderStatus.Approved, 4, 21, ErrorCode.GreaterPriceApproved, ErrorCode.GreaterQuantityApproved)]
        [InlineData(OrderStatus.Approved, 2, 20, ErrorCode.LowerQuantityApproved)]
        [InlineData(OrderStatus.Disapproved, 0, 0, ErrorCode.Disapproved)]
        public void GetStatus(OrderStatus status, int approvedItems, decimal approvedPrice, params ErrorCode[] statusResult)
        {
            var result = statusResult.Select(x => x.GetDescription());

            var orderStatus = _order.GetOrderStatus(status, approvedItems, approvedPrice);

            Assert.True(result.All(x => orderStatus.Any(y => y == x)));
            Assert.True(orderStatus.All(x => result.Any(y => y == x)));
        }
    }
}