namespace MinhaAplicacao_API.V1.Models
{
    public class StatusPedidoModel
    {
        public string Status { get; set; }
        public int ItensAprovados { get; set; }
        public decimal ValorAprovado { get; set; }
        public string Pedido { get; set; }
    }
}
