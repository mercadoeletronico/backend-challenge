using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercadoEletronico.Domain.Entities
{
    public class Pedido : IEntity
    {
        public Pedido()
        {
            Itens = new List<PedidoItem>();
        }

        public int Id { get; set; }

        public List<PedidoItem> Itens { get; set; }
    }
}