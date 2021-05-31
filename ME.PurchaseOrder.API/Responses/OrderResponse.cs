using System.Collections.Generic;

namespace ME.PurchaseOrder.API.Responses
{
    public class OrderResponse : BaseResponse
    {
        public OrderResponse()
        {
        }

        public OrderResponse(int statusCode) : base(statusCode)
        {
        }

        public string Pedido { get; set; }
        public List<OrderItemResponse> Itens { get; set; }
    }
}