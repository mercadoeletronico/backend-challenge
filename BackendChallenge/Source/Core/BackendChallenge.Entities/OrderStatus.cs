namespace BackendChallenge.Entities
{
    public struct OrderStatus
    {
        public string OrderNumber { get; set; }

        public int ApprovedQuantity { get; set; }

        public int ApprovedPrice { get; set; }

        public Status Status { get; set; }
    }
}
