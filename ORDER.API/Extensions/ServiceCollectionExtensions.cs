using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ORDER.API.AutoMapper;
using ORDER.Application.Services;
using ORDER.Domain.Repositories;
using ORDER.Domain.Services;
using ORDER.Infra.Data;
using ORDER.Infra.Repositories;

namespace ORDER.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbConnection(this IServiceCollection services, string connString){
            var contextOptions = new DbContextOptionsBuilder<Context>()
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase(Environment.GetEnvironmentVariable(connString) ?? string.Empty)
                .Options;
            var ctx = new Context(contextOptions);
            
            ctx.SaveChanges();
            ctx.Database.EnsureCreated();
            services.AddSingleton(_ => ctx);
        }
        
        public static void AddRepositories(this IServiceCollection services){
            // services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
        }
        
        public static void AddServices(this IServiceCollection services){
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IStatusService, StatusService>();
        }
        
        public static void AddFactory(this IServiceCollection services){
            // services.AddTransient<ItemFactory>();
        }
        
        public static void AddAutoMapper(this IServiceCollection services){
            
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AddProfile(new GenericMapper());
            });

            var mapper = autoMapperConfig.CreateMapper();
            
            services.AddSingleton(mapper);
        }
    }
}