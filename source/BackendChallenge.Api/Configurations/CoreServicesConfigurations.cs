using BackendChallenge.Api.Interfaces;
using BackendChallenge.Api.Services;
using BackendChallenge.Core.Interfaces;
using BackendChallenge.Infrastructure.Repositories;
using BackendChallenge.Infrastructure.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace BackendChallenge.Api.Configurations
{
    public static class CoreServicesConfigurations
    {
        public static IServiceCollection AddCoreServicesConfigurations(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderStatusService, OrderStatusService>();

            return services;
        }
    }
}
