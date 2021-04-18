namespace MercadoEletronico.Challenge.Domain.Models.Entities
{
    public class PedidoItem : Entity
    {
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public uint Qtd { get; set; }
        public string PedidoId { get; set; }
    }
}
