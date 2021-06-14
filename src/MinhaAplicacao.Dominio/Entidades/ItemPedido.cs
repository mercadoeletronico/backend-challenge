namespace MinhaAplicacao.Dominio.Entidades
{
    public class ItemPedido : EntidadeBase<int>
    {
        public ItemPedido()
        {
        }

        public ItemPedido(string descricao, decimal precoUnitario, int quantidade, int pedidoId)
        {
            this.Descricao = descricao;
            this.PrecoUnitario = precoUnitario;
            this.Quantidade = quantidade;
            this.PedidoId = pedidoId;
        }

        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }

        public int PedidoId { get; set; }

        public virtual Pedido Pedido { get; set; }
    }
}
