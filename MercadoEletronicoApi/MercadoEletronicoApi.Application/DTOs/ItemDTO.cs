namespace MercadoEletronicoApi.Application.DTOs
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public int PedidoId { get; set; }
    }
}
