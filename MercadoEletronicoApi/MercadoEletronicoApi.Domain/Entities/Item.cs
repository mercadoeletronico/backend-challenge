namespace MercadoEletronicoApi.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public int? OrderId { get; set; }
        public Order Order { get; set; }

        public decimal Cost => UnitPrice * Quantity;

    }

}
