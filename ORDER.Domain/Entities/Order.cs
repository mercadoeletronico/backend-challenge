using System.Collections.Generic;
using System.Text.Json.Serialization;
using ORDER.Domain.Entities.Base;

namespace ORDER.Domain.Entities
{
    public class Order : Entity
    {
        public string OrderId { get; set; }
        
        public List<Item> Items { get; set; }
    }
}