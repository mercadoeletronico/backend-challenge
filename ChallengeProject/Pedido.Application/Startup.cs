using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Pedido.Domain.Repositories;
using Pedido.Domain.Services;
using Pedido.Infra;
using Pedido.Infra.Repository;

namespace Pedido.Application
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Challenge - Pedido Api",
                    Description = "Api Asp Net Core for maintenance of requests",
                    Contact = new OpenApiContact() { Name = "Ana Paula de Souza", Email = "anasouza.0309@gmail.com" }
                });
            });


            services.AddDbContext<PedidoDbContext>(options =>
            {
                options.UseInMemoryDatabase("pedido-api-in-memory");
            });

            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoService, PedidoService>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseExceptionHandler(
            options =>
            {
                options.Run(
                    async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "text/html";
                        var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
                        if (null != exceptionObject)
                        {
                            var errorMessage = $"<b>Error: {exceptionObject.Error.Message}</ b > { exceptionObject.Error.StackTrace}";

                            await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
                        }
                    });
            });


        }
    }
}
