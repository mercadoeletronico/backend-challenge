using ME.PurchaseOrder.Domain.Interfaces;
using ME.PurchaseOrder.Domain.Models;
using ME.PurchaseOrder.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ME.PurchaseOrder.Infra.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(BaseContext baseContext) : base(baseContext)
        {
        }

        public async Task<Order> GetOrderByCode(string numberOrder)
            => await _dbSet.Include(x => x.Items).FirstOrDefaultAsync(x => x.NumberOrder == numberOrder);

        public override Task<Order> Find(int id)
        {
            _dbSet.Include(x => x.Items);

            return base.Find(id);
        }

        public override void Insert(Order entity)
        {
            if (entity.Items?.Any() ?? false)
                _dbSet.Include(p => p.Items);

            base.Insert(entity);
        }

        public override void Update(Order entity)
        {
            if (entity.Items?.Any() ?? false)
                _dbSet.Include(p => p.Items);

            base.Update(entity);
        }
    }
}