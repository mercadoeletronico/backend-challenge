using ORDER.Domain.Entities.Base;

namespace ORDER.Domain.Entities
{
    public class Item : Entity
    {
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
    }
}

