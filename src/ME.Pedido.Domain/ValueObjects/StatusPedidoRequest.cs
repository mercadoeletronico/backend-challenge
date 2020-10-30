namespace ME.Pedido.Domain.ValueObjects
{
    public class StatusPedidoRequest
    {
        public string status { get; set; }
        public int itensAprovados { get; set; }
        public int valorAprovado { get; set; }
        public string pedido { get; set; }
    }
}
