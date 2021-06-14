namespace MinhaAplicacao_API.V1.Models
{
    public class ItemPedidoModel : ModelBase<int>
    {
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}