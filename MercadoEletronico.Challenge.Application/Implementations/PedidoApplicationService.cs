using MercadoEletronico.Challenge.Application.Interfaces;
using MercadoEletronico.Challenge.Domain.Models.Entities;
using MercadoEletronico.Challenge.Domain.Models.Requests;
using MercadoEletronico.Challenge.Domain.Models.Responses;
using MercadoEletronico.Challenge.Domain.Services.Interfaces;
using MercadoEletronico.Challenge.Util;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MercadoEletronico.Challenge.Application.Implementations
{
    public class PedidoApplicationService : ApplicationService<Pedido>, IPedidoApplicationService
    {
        private IPedidoDomainService PedidoService => (IPedidoDomainService)_domainService;

        public PedidoApplicationService(
            IPedidoDomainService domainService,
            ILogger<ApplicationService<Pedido>> logger) 
                : base(domainService, logger)
        {
        }

        public async Task<Result<StatusResponse>> AprovarPedido(StatusRequest request)
        {
            if (request is null) 
            {
                return new Result<StatusResponse>(ResultStatus.BadRequest, $"{nameof(request)} cannot be null");
            }

            return await Catch(() => PedidoService.AprovarPedido(request));
        }
    }
}
