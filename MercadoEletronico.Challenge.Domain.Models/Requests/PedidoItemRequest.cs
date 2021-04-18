namespace MercadoEletronico.Challenge.Domain.Models.Resquests
{
    public class PedidoItemRequest
    {
        public string Descricao { get; set; }
        public decimal? PrecoUnitario { get; set; }
        public uint Qtd { get; set; }
    }
}