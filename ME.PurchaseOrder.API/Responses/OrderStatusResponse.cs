using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ME.PurchaseOrder.API.Responses
{
    public class OrderStatusResponse : BaseResponse
    {
        public OrderStatusResponse()
        {
        }

        public OrderStatusResponse(int statusCode) : base(statusCode)
        {
        }

        public OrderStatusResponse(string pedido, List<string> status)
        {
            StatusCode = StatusCodes.Status200OK;
            Pedido = pedido;
            Status = status;
        }

        public string Pedido { get; set; }
    }
}