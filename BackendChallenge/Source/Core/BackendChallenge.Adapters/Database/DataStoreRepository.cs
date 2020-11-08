using System.Collections.Generic;
using System.Linq;

using BackendChallenge.Ports.Adapters.Database;

using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.Adapters.Database
{
    class DataStoreRepository<TEntity> : IDataStoreRepository<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> _entity;

        public DataStoreRepository(DataStoreContext context)
        {
            _entity = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return _entity.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return _entity.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _entity.Add(entity);
        }

        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            _entity.AddRange(entities);
        }

        public virtual void Delete(TEntity entity)
        {
            _entity.Remove(entity);
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            _entity.RemoveRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            _entity.Update(entity);
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            _entity.UpdateRange(entities);
        }
    }
}
