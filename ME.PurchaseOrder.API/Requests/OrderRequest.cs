using System.Collections.Generic;

namespace ME.PurchaseOrder.API.Requests
{
    public class OrderRequest
    {
        public string Pedido { get; set; }
        public ICollection<OrderItemRequest> Itens { get; set; }
    }
}