namespace MercadoEletronico.Domain.Requests
{
    public class StatusRequest
    {
        public string Status { get; set; }

        public int ItensAprovados { get; set; }

        public decimal ValorAprovado { get; set; }

        public int Pedido { get; set; }
    }
}