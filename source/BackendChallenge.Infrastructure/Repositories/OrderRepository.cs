using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendChallenge.Core.Entities;
using BackendChallenge.Core.Interfaces;
using BackendChallenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(BackendChallengeDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>List of entities</returns>
        public override async Task<List<Order>> AllAsync()
        {
            return await _dbContext
                .Orders
                .Include(o => o.Items)
                .ToListAsync();
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity instance</returns>
        public override async Task<Order> FindByIdAsync(int id)
        {
            return await _dbContext
                .Orders
                .Include(o => o.Items)
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
