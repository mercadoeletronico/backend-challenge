namespace ME.PurchaseOrder.API.Responses
{
    public class OrderItemResponse : BaseResponse
    {
        public OrderItemResponse()
        {
        }

        public OrderItemResponse(int statusCode) : base(statusCode)
        {
        }

        public string Descricao { get; set; }
        public int PrecoUnitario { get; set; }
        public int Qtd { get; set; }
    }
}