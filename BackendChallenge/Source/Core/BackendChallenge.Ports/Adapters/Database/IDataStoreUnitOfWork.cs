using System.Threading.Tasks;

using BackendChallenge.Entities;

namespace BackendChallenge.Ports.Adapters.Database
{
    public interface IDataStoreUnitOfWork
    {
        IDataStoreRepository<Order> Orders { get; }

        IDataStoreRepository<OrderItem> OrderItems { get; }

        Task Commit();
    }
}