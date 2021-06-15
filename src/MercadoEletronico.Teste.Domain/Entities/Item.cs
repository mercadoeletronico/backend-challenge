using System;

namespace MercadoEletronico.Teste.Domain.Entities
{
    public class Item : Entity
    {
        public Guid PedidoId { get; set; }
        public string Descricao { get; set; }
        public int PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public Pedido Pedido { get; set; }
    }
}