using System.Collections.Generic;

namespace MercadoEletronico.Challenge.Domain.Models.Entities
{
    public class Pedido
    {
        public Pedido()
        {
            Itens = new List<PedidoItem>();
        }

        public string Id { get; set; }

        public List<PedidoItem> Itens { get; set; }
    }
}
