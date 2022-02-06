using System.Collections.Generic;

namespace MercadoEletronicoApi.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }

        public IList<Item> Items { get; set; }

    }

}
