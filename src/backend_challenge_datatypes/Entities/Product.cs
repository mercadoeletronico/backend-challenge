using System;

namespace backend_challenge_datatypes.Entities
{
    public class Product
        : TransactionalEntityBase
    {
        public string ReferenceCode { get; set; }
        public string Description { get; set; }
        
    }
}