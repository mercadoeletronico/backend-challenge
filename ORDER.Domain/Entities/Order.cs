using System.Collections.Generic;
using System.Linq;
using ORDER.Domain.Entities.Base;

namespace ORDER.Domain.Entities
{
    public class Order : Entity
    {
        public string OrderId { get; set; }

        public List<Item> Items { get; set; }

        public int ItemsCount() => Items.Sum(x => x.Quantity);
        public int ItemsValue() => Items.Sum(x => x.Cost);
    }
}