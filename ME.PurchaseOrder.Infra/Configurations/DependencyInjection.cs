using ME.PurchaseOrder.Domain.Interfaces;
using ME.PurchaseOrder.Infra.Repositories;
using ME.PurchaseOrder.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ME.PurchaseOrder.Infra.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
        {
            services.AddDbContext<BaseContext>(opt => opt.UseInMemoryDatabase("DEV_ME_DB"));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            return services;
        }
    }
}