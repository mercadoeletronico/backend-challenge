using App.Domain.Commands.Handlers;
using App.Domain.Repositories;
using App.Infrastructure.Contexts;
using App.Infrastructure.Repositories;
using App.Infrastructure.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Api
{
    public static class DependenceResolver
    {
        public static void Register(IServiceCollection services)
        {

            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(@"Server=DESKTOP-A9IB29C\SQLEXPRESS; Database=medatabase; User Id=sa; Password=senhadatabase;"));

            services.AddScoped<ApplicationContext, ApplicationContext>();
            services.AddTransient<IUow, Uow>();

            services.AddTransient<IPedidosRepository, PedidosRepository>();
            services.AddTransient<PedidosCommandHandler, PedidosCommandHandler>();


        }
    }
}
