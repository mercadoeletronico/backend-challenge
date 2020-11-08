using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MercadoEletronico.Utilities.Data
{
    public interface IUnityOfWork
    {
        Task<bool> CommitAsync(CancellationToken cancellationToken);
    }
}
