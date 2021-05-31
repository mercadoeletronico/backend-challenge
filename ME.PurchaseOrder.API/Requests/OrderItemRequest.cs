namespace ME.PurchaseOrder.API.Requests
{
    public class OrderItemRequest
    {
        public string Descricao { get; set; }
        public int Qtd { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}