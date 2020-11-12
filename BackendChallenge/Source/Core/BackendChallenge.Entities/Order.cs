using System.Collections.Generic;
using System.Linq;

namespace BackendChallenge.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public Status? Status { get; set; }

        public OrderStatus? OrderStatus { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();


        public int CalculateTotalOrderItemQuantity()
        {
            return Items.Sum(item => item.Quantity);
        }

        public int CalculateTotalOrderAmount()
        {
            return Items.Sum(item => item.UnitPrice * item.Quantity);
        }
    }
}
