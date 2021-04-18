using MercadoEletronico.Challenge.Domain.Models.Entities;
using MercadoEletronico.Challenge.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace MercadoEletronico.Challenge.Application.Implementations
{
    public class PedidoApplicationService : ApplicationService<Pedido>, IPedidoApplicationService
    {
        public PedidoApplicationService(
            IPedidoDomainService domainService,
            ILogger<ApplicationService<Pedido>> logger) 
                : base(domainService, logger)
        {
        }
    }
}
