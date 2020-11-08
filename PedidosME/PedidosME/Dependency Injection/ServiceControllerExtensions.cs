using AutoMapper;
using MediatR;
using MercadoEletronico.Utilities.Bus;
using MercadoEletronico.Utilities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PedidosME.BusServices;
using PedidosME.Data.DataContext;
using PedidosME.Data.Repositories;
using PedidosME.Domain.DTOs.Mappers;
using PedidosME.Domain.Entities.PedidoAggregate;
using PedidosME.Domain.Handlers;
using PedidosME.Domain.Services;
using System;

namespace PedidosME.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServiceContainer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainMappers).Assembly);
            services.AddDbContext<DbContext, PedidosMEDbContext>(opt => opt.UseInMemoryDatabase("PedidosME"));
            services.AddScoped(typeof(IGenericRepository<>), typeof(DefaultRepository<>));
            services.AddScoped<IPedidoRepository, PedidoRepository>()
                .AddSingleton<IBusServices, BusProvider>()
                .AddScoped<IPedidoServices, PedidoServices>()
                .AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
