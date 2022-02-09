using MercadoEletronicoApi.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace MercadoEletronicoApi.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string OrderCode { get; set; }

        public IList<Item> Items { get; set; }

        public Order()
        {
        }

        public Order(int id, string codPedido)
        {
            OrderException.When(id < 0 , "Invalid id value.");
            OrderException.When(string.IsNullOrEmpty(codPedido), "Order code is required.");
            Id = id;
            OrderCode = codPedido;
        }

        public int GetTotalOrderItems() 
        {
            OrderException.When(Items is null, "Order without items.");
            return Items.Sum(x => x.Quantity);
        }

        public decimal GetTotalOrderAmount()
        {
            OrderException.When(!Items.Any(), "Unable to calculate total amount: order without items.");
            return Items.Sum(x => x.Cost);
        }

    }

}
