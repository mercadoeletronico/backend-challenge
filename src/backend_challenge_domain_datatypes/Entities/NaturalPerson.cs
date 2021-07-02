using System;
using Vrnz2.Infra.CrossCutting.Types;

namespace backend_challenge_domain_datatypes.Entities
{
    public class NaturalPerson
        : TransactionalEntityBase
    {
        public Guid PersonId { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
    }
}
