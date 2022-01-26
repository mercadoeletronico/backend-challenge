using Microsoft.Extensions.DependencyInjection;

namespace ORDER.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbConnection(this IServiceCollection services, string connString){
            // var contextOptions = new DbContextOptionsBuilder<Context>()
                // .UseNpgsql(Environment.GetEnvironmentVariable(connString) ?? string.Empty)
                // .Options;

            // services.AddTransient(_ => new Context(contextOptions));
        }
        
        public static void AddRepositories(this IServiceCollection services){
            // services.AddTransient<IItemRepository, ItemRepository>();
        }
        
        public static void AddServices(this IServiceCollection services){
            // services.AddTransient<IItemService, ItemService>();
        }
        
        public static void AddFactory(this IServiceCollection services){
            // services.AddTransient<ItemFactory>();
        }
    }
}