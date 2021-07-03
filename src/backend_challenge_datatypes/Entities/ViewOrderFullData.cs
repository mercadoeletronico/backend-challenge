using System;

namespace backend_challenge_datatypes.Entities
{
    public class ViewOrderFullData
    {
        public string Number { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }        
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string SellerCode { get; set; }
        public string SellerName { get; set; }
    }
}
