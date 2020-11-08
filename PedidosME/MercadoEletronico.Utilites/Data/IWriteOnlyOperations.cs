using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MercadoEletronico.Utilities.Data
{
    public interface IWriteOnlyOperations<TEntity> : IDisposable
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
