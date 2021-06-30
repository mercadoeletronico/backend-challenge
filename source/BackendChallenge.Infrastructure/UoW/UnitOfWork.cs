using System.Threading.Tasks;
using BackendChallenge.Core.Interfaces;
using BackendChallenge.Infrastructure.Data;

namespace BackendChallenge.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly BackendChallengeDbContext _dbContext;

        public UnitOfWork(BackendChallengeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Saves all changes made in database context to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Releases the allocated resources in database context.
        /// </summary>
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
