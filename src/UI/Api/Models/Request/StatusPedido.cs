namespace Api.Models.Request
{
    public class StatusPedido
    {
        public string Status { get; set; }
        public int ItensAprovados { get; set; }
        public double ValorAprovado { get; set; }
        public string Pedido { get; set; }

    }
}