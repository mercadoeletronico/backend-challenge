using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackendChallenge.Core.Interfaces;
using BackendChallenge.Infrastructure.Data;

namespace BackendChallenge.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BackendChallengeDbContext _dbContext;

        public Repository(BackendChallengeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        public virtual void Add(TEntity entity)
        {
            _dbContext.Add(entity);
        }

        /// <summary>
        /// Add many entities
        /// </summary>
        /// <param name="entity">Entities</param>
        public virtual void AddMany(List<TEntity> entities)
        {
            _dbContext.AddRange(entities);
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity instance</returns>
        public virtual async Task<TEntity> FindByIdAsync(int id)
        {
            return await _dbContext
                .Set<TEntity>()
                .FindAsync(id);
        }

        /// <summary>
        /// Count all async
        /// </summary>
        /// <returns>Entities total</returns>
        public virtual async Task<int> CountAsync()
        {
            return await _dbContext
                .Set<TEntity>()
                .CountAsync();
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>List of entities</returns>
        public virtual async Task<List<TEntity>> AllAsync()
        {
            return await _dbContext
                .Set<TEntity>()
                .ToListAsync();
        }

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        public virtual void Update(TEntity entity)
        {
            _dbContext
                .Set<TEntity>()
                .Update(entity);
        }

        /// <summary>
        /// Remove entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        public virtual void Remove(TEntity entity)
        {
            _dbContext
                .Set<TEntity>()
                .Remove(entity);
        }

        /// <summary>
        /// Remove many entities
        /// </summary>
        /// <param name="entity">Entities</param>
        public virtual void RemoveMany(List<TEntity> entities)
        {
            _dbContext
                .Set<TEntity>()
                .RemoveRange(entities);
        }
    }
}
