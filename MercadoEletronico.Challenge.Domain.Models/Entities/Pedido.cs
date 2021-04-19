using System.Collections.Generic;

namespace MercadoEletronico.Challenge.Domain.Models.Entities
{
    public class Pedido : Entity
    {
        public Pedido()
        {
            Itens = new List<PedidoItem>();
        }

        public List<PedidoItem> Itens { get; set; }
    }
}
