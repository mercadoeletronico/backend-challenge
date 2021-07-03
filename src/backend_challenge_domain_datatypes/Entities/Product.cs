using System;

namespace backend_challenge_domain_datatypes.Entities
{
    public class Product
        : TransactionalEntityBase
    {
        public string ReferenceCode { get; set; }
        public string Description { get; set; }
        
    }
}