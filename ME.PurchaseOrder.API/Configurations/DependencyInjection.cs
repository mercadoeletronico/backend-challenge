using Microsoft.Extensions.DependencyInjection;

namespace ME.PurchaseOrder.API.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return services;
        }
    }
}