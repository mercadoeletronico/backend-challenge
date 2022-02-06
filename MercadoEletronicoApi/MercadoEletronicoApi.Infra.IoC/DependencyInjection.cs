using MercadoEletronicoApi.Application.AutoMapper;
using MercadoEletronicoApi.Application.Interfaces;
using MercadoEletronicoApi.Application.Services;
using MercadoEletronicoApi.Domain.Interfaces;
using MercadoEletronicoApi.Infra.Data.Context;
using MercadoEletronicoApi.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MercadoEletronicoApi.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<MercadoEletronicoDbContext>(options => {
                options.UseInMemoryDatabase("MeDbContextInMemory");
                options.EnableSensitiveDataLogging();
            });
            
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IItemService, ItemService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }

    }
}
