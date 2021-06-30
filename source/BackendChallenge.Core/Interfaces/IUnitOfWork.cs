using System;
using System.Threading.Tasks;

namespace BackendChallenge.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves all changes made in database context to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        Task<int> CommitAsync();
    }
}
