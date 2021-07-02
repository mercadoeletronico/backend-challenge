using System;

namespace backend_challenge_domain_datatypes.Entities
{
    public class Address
        : TransactionalEntityBase
    {
        public Guid PersonId { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
