using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MercadoEletronico.Utilities.Bus
{
    public interface IBusServices
    {
        Task Send(string message, CancellationToken cancellationToken);
    }
}
