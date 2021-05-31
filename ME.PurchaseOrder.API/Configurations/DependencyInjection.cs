using FluentValidation.AspNetCore;
using ME.PurchaseOrder.API.Interfaces;
using ME.PurchaseOrder.API.Serivces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ME.PurchaseOrder.API.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(Startup));
            services.AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddTransient<IOrderService, OrderService>();

            return services;
        }
    }
}