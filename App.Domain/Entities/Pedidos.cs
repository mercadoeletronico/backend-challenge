using System.Collections.Generic;
using System.Linq;

namespace App.Domain.Entities
{
    public class Pedido
    {
        private readonly IList<ItensPedido> _items;
        public Pedido()
        {
            _items = new List<ItensPedido>();
        }

        public Pedido(int pedido)
        {
            this.CodigoPedido = pedido;
            _items = new List<ItensPedido>();
        }

        public int Id { get; private set; }
        public int CodigoPedido { get; private set; }
        public ICollection<ItensPedido> Itens => _items.ToArray();

        public void AddItem(ItensPedido item)
        {
            _items.Add(item);
        }
    }
}
