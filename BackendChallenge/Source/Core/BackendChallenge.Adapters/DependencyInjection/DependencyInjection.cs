using BackendChallenge.Adapters.Database;
using BackendChallenge.Ports.Adapters.Database;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BackendChallenge.Adapters.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseInMemory(this IServiceCollection services)
        {
            services.AddDbContextPool<DataStoreContext>(ctx =>
            {
                ctx.UseLazyLoadingProxies()
                   .UseInMemoryDatabase(nameof(DataStoreContext));
            });

            services.AddTransient<IDataStoreUnitOfWork, DataStoreUnitOfWork>();

            return services;
        }
    }
}
