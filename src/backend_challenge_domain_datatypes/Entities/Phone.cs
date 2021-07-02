using System;

namespace backend_challenge_domain_datatypes.Entities
{
    public class Phone
        : TransactionalEntityBase
    {
        public Guid PersonId { get; set; }
        public string Ddi { get; set; }
        public string Ddd { get; set; }
        public string Number { get; set; }
    }
}
