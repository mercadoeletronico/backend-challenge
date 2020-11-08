using MercadoEletronico.Utilities.Bus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PedidosME.BusServices
{
    public class BusProvider : IBusServices
    {
        private readonly ILogger<BusProvider> logger;

        public BusProvider(ILogger<BusProvider> logger)
        {
            this.logger = logger;
        }
        public Task Send(string message, CancellationToken cancellationToken)
        {
            return Task.Run(()=> logger.LogInformation($"|BusProvider| mensagem envida: {message}"),cancellationToken);
        }
    }
}
