using BackendChallenge.Core.Entities;
using BackendChallenge.Core.Interfaces;
using BackendChallenge.Infrastructure.Data;

namespace BackendChallenge.Infrastructure.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(BackendChallengeDbContext dbContext) : base(dbContext)
        {
        }
    }
}
