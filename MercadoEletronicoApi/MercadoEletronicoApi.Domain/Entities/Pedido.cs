using System.Collections.Generic;
using System.Linq;

namespace MercadoEletronicoApi.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }

        public IList<Item> Items { get; set; }

        public int TotalItens() 
        {
            return Items.Sum(x => x.Quantidade);
        }

        public decimal ValorTotal() 
        {
            return Items.Sum(x => x.Custo);
        }
       
    }

}
