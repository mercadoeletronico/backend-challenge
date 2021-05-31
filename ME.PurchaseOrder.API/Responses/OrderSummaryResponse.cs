namespace ME.PurchaseOrder.API.Responses
{
    public class OrderSummaryResponse : BaseResponse
    {
        public OrderSummaryResponse()
        {
        }

        public OrderSummaryResponse(int statusCode) : base(statusCode)
        {
        }

        public string Pedido { get; set; }
    }
}