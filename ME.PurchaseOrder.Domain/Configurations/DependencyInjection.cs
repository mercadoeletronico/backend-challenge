using FluentValidation.Results;
using ME.PurchaseOrder.Domain.Commands;
using ME.PurchaseOrder.Domain.Commands.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ME.PurchaseOrder.Domain.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateOrderCommand, ValidationResult>, OrderCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateOrderCommand, ValidationResult>, OrderCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteOrderCommand, ValidationResult>, OrderCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateOrderStatusCommand, ValidationResult>, OrderCommandHandler>();

            return services;
        }
    }
}