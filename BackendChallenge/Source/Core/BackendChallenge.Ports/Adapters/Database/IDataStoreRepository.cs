using System.Collections.Generic;

namespace BackendChallenge.Ports.Adapters.Database
{
    public interface IDataStoreRepository<TEntity>
        where TEntity : class
    {
        IEnumerable<TEntity> Get();

        TEntity GetById(object id);

        void Insert(IEnumerable<TEntity> entities);

        void Insert(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
    }
}