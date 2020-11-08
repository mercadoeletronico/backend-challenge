using System;
using System.Collections.Generic;
using System.Text;

namespace MercadoEletronico.Utilities.Data
{
    public interface IGenericRepository<TEntity> : IReadOnlyOperations<TEntity>, IWriteOnlyOperations<TEntity>, IUnityOfWork
    {
    }
}
