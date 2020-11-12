using System.Collections.Generic;
using System.Reflection;

using BackendChallenge.Application.Validators;
using BackendChallenge.Ports.Application.BusinessRules;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace BackendChallenge.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetAssembly(typeof(DependencyInjection)));

            services.AddTransient<IEnumerable<IRule>>(ctx =>
            {
                return new IRule[]
                {
                    new InvalidOrderNumberRule(),
                    new DisapprovedOrderRule(),
                    new ApprovedOrderRule(),
                    new ApprovedOrderWithLargerQuantityRule(),
                    new ApprovedOrderWithHigherValueRule(),
                    new ApprovedOrderWithSmallerQuantityRule(),
                    new ApprovedOrderWithLowerValueRule()
                };
            });

            return services;
        }
    }
}
