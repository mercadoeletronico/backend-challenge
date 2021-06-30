using BackendChallenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BackendChallenge.Api.Configurations
{
    public static class DbContextConfigurations
    {
        public static IServiceCollection AddDbContextConfigurations(this IServiceCollection services)
        {
            services.AddDbContext<BackendChallengeDbContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"));

            return services;
        }
    }
}
