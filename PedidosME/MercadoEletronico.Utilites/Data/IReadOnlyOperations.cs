using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MercadoEletronico.Utilities.Data
{
    public interface IReadOnlyOperations<TEntity> : IDisposable  
    {
        Task<TEntity> GetByKeysAsync(CancellationToken cancellationToken, params object[] keys);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            bool noTracking = false, int? take = null);
    }
}
