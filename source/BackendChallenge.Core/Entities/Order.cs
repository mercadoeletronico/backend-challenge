using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendChallenge.Core.Entities
{
    public class Order
    {
        [Key]
        public Int32 Id { get; set; }
        public List<Item> Items { get; set; }
    }
}
