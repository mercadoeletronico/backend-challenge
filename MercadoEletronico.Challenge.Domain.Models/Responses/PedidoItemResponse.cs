namespace MercadoEletronico.Challenge.Domain.Models.Responses
{
    public class PedidoItemResponse
    {
        public string Descricao { get; set; }
        public decimal? PrecoUnitario { get; set; }
        public uint Qtd { get; set; }
    }
}