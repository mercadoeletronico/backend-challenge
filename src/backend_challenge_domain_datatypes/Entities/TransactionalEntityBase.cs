namespace backend_challenge_domain_datatypes.Entities
{
    public class TransactionalEntityBase
        : EntityBase
    {
        public bool Deleted { get; set; }
    }
}
