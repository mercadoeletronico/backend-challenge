using System.Threading.Tasks;

using BackendChallenge.Entities;
using BackendChallenge.Ports.Adapters.Database;

namespace BackendChallenge.Adapters.Database
{
    public class DataStoreUnitOfWork : IDataStoreUnitOfWork
    {
        private readonly DataStoreContext _context;

        private DataStoreRepository<Order> _orders;

        private DataStoreRepository<OrderItem> _orderItems;

        public DataStoreUnitOfWork(DataStoreContext context)
        {
            _context = context;
        }

        public IDataStoreRepository<Order> Orders
            => _orders ??= new DataStoreRepository<Order>(_context);

        public IDataStoreRepository<OrderItem> OrderItems
            => _orderItems ??= new DataStoreRepository<OrderItem>(_context);

        public async Task Commit()
            => await _context.SaveChangesAsync();
    }
}
