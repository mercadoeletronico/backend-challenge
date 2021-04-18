using MercadoEletronico.Challenge.Application.Implementations;
using MercadoEletronico.Challenge.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MercadoEletronico.Challenge.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services) 
        {
            services.AddScoped<IPedidoApplicationService, PedidoApplicationService>();        
        }
    }
}
