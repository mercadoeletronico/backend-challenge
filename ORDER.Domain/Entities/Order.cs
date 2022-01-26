using System.Collections.Generic;

namespace ORDER.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
    }
}