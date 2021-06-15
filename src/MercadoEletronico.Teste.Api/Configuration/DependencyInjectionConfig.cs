using MercadoEletronico.Teste.Application.Interfaces;
using MercadoEletronico.Teste.Application.Notificacoes;
using MercadoEletronico.Teste.Application.Services;
using MercadoEletronico.Teste.Infra.Context;
using MercadoEletronico.Teste.Infra.Interfaces;
using MercadoEletronico.Teste.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MercadoEletronico.Teste.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IPedidoService, PedidoService>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}