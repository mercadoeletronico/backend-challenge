using Microsoft.Extensions.DependencyInjection;
using MinhaAplicacao.Dominio.Interfaces.Repositories;
using MinhaAplicacao.Dominio.Interfaces.Services;
using MinhaAplicacao.Infraestrutura;
using MinhaAplicacao.Infraestrutura.Repositorios;
using MinhaAplicacao.Negocio.Services;

namespace MinhaAplicacao_API.Common.Configurations
{
    public static class IoCConfig
    {
        public static IServiceCollection CarregarDependencias(this IServiceCollection services)
        {
            #region Repositorios

            services.AddScoped<MinhaAplicacaoDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();

            #endregion

            #region Serviços

            services.AddScoped<IPedidoServico, PedidoServico>();

            #endregion

            return services;
        }
    }
}
