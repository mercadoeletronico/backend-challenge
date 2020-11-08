namespace BackendChallenge.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int UnitPrice { get; set; }

        public int Quantity { get; set; }


        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
