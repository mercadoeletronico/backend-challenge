using MercadoEletronico.Aplication.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace MercadoEletronico.Aplication
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Banco de Dados
            services.AddSingleton<DataAccess.Context>();

            //Notificador
            services.AddScoped<Business.Interfaces.INotificador, Business.Notificacoes.Notificador>();

            //Repositório
            services.AddScoped<Business.Interfaces.IRepositorioService, Business.Services.RepositorioService>();

            //AutoMapper
            services.RegisterMappings();

            //Routes
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            services.AddSwaggerGenNewtonsoftSupport();

            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MercadoEletronico.Aplication", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mercado Eletrônico v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}