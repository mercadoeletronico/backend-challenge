namespace backend_challenge_datatypes.Responses
{
    public class GetOrderItemResponse
    {
        public string codigoProduto { get; set; }
        public string descricao { get; set; }
        public decimal precoUnitario { get; set; }
        public decimal qtd { get; set; }
    }
}