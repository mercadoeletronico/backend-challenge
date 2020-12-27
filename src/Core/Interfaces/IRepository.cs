using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> FetchAll();
        TEntity Add(TEntity entity);
        void Delete(TEntity entity);
        void Save();
    }
}
