namespace MercadoEletronicoApi.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }

        public int? PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public decimal Custo => PrecoUnitario * Quantidade;

    }

}
