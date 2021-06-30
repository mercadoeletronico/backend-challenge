using System;
using System.ComponentModel.DataAnnotations;

namespace BackendChallenge.Core.Entities
{
    public class Item
    {
        [Key]
        public Int32 Id { get; set; }
        [Required]
        public string Description { get; set; }
        public Int32 Quantity { get; set; }
        public Int32 Price { get; set; }
        [Required]
        public Int32 OrderId { get; set; }
        public Order Order { get; set; }
    }
}
