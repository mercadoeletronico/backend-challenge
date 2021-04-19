using MercadoEletronico.Challenge.DataAccess.Repositories;
using MercadoEletronico.Challenge.Domain.Services.Interfaces.Data_Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MercadoEletronico.Challenge.DataAccess.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDataAccessLayer(this IServiceCollection services) 
        {
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("MercadoEletronicoDB"));
        }
    }
}
