namespace MercadoEletronico.Challenge.Domain.Models.Entities.Value_Objects
{
    public class PedidoItem
    {
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public uint Qtd { get; set; }
    }
}
