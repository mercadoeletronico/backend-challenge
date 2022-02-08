using System.Collections.Generic;
using System.Linq;

namespace MercadoEletronicoApi.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }

        public string CodPedido { get; set; }

        public IList<Item> Items { get; set; }

        public int TotalItens() => Items.Sum(x => x.Quantidade);

        public decimal ValorTotal() => Items.Sum(x => x.Custo);

    }

}
