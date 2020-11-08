using System.Reflection;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace BackendChallenge.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetAssembly(typeof(DependencyInjection)));

            return services;
        }
    }
}
