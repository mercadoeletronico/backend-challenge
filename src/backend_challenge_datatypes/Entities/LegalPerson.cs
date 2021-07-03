using System;

namespace backend_challenge_datatypes.Entities
{
    public class LegalPerson
        : TransactionalEntityBase
    {
        public Guid PersonId { get; set; }
        public string Cnpj { get; set; }
        public string LegalName { get; set; }
    }
}
