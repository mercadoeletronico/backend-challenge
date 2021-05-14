using Domain.CommandHandler;
using Domain.Commands;
using Domain.Notifications;
using Domain.Queries;
using Domain.Repositories;
using Infra.BD;
using Infra.Repositories;
using Infra.Repositories.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //transiente para ser diferente em cada solicitação dele
            services.AddTransient<CommandHandler<PedidoCommand, bool>, CadastrarPedidoCommandHandler>();
            services.AddTransient<CommandHandler<PedidoCommand, string>, AtualizarPedidoCommandHandler>();

            //Scoped = cada solicitação(novo scopo) ele cria um novo 
            services.AddScoped<IPedidoQueryRepository, PedidoQueryRepository>();
            services.AddScoped<IPedidoQuery, PedidoQuey>();
            //transiente = sera injetado todo vez por request
            services.AddTransient<IPedidoCommandRepository, PedidoCommandRepository>();
            
            // "BANCO DE DADOS" em memoria
            services.AddSingleton<Banco>();



            services.AddScoped<NotificationPool>();
            services.AddMvc(c => c.EnableEndpointRouting = false);
            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new OpenApiInfo { Title = "Service Mercado Eletronico Pedidos", Version = "v1" });

               c.EnableAnnotations();
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Service Pedidos v1");
                c.RoutePrefix = string.Empty;  // Set Swagger UI at apps root
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseMvc();
        }
    }
}
