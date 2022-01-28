using System.Collections.Generic;
using ORDER.Domain.Entities.Base;

namespace ORDER.Domain.Entities
{
    public class Order : Entity
    {
        public string OrderId { get; set; }
        
        public List<Item> Items { get; set; }
    }
}