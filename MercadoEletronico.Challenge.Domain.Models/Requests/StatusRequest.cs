namespace MercadoEletronico.Challenge.Domain.Models.Requests
{
    public class StatusRequest
    {
        public string Pedido { get; set; }
        public string Status { get; set; }
        public uint ItensAprovados { get; set; }
        public decimal ValorAprovado { get; set; }
    }
}
