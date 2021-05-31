using ME.PurchaseOrder.API.Requests.Enums;
using ME.PurchaseOrder.Domain.Enums;

namespace ME.PurchaseOrder.API.Extensions
{
    public static class OrderStatusRequestExtension
    {
        public static OrderStatus ToOrderStatus(this OrderStatusRequest orderStatusRequest)
            => orderStatusRequest switch
            {
                OrderStatusRequest.Aprovado => OrderStatus.Approved,
                OrderStatusRequest.Reprovado => OrderStatus.Disapproved,
                _ => default,
            };
    }
}