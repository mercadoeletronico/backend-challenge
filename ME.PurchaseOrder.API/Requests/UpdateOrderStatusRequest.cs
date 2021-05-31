using ME.PurchaseOrder.API.Requests.Enums;

namespace ME.PurchaseOrder.API.Requests
{
    public class UpdateOrderStatusRequest
    {
        public OrderStatusRequest Status { get; set; }
        public int ItensAprovados { get; set; }
        public decimal ValorAprovado { get; set; }
        public string Pedido { get; set; }
    }
}