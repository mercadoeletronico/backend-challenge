namespace Pedido.Domain.Models
{
    public class PedidoStatusRequest
    {
        public string Pedido { get; set; }

        public int ItensAprovados { get; set; }

        public decimal ValorAprovado { get; set; }

        public Status Status { get; set; }

    }
}