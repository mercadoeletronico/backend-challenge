using System;

namespace backend_challenge_datatypes.Entities
{
    public class ViewCustomerFullData
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }
        public Guid PersonId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Ddd { get; set; }
        public string PhoneNumer { get; set; }
        public string EmailAddress { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
