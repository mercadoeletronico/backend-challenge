using MercadoEletronico.Challenge.Domain.Services.Implementations;
using MercadoEletronico.Challenge.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MercadoEletronico.Challenge.Domain.Services.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDomainLayer(this IServiceCollection services) 
        {
            services.AddScoped<IPedidoDomainService, PedidoDomainService>();
        }
    }
}
