namespace MinhaAplicacao.Dominio.Entidades
{
    public class StatusPedido
    {
        public string Status { get; set; }
        public int ItensAprovados { get; set; }
        public decimal ValorAprovado { get; set; }
        public string Pedido { get; set; }
    }
}
