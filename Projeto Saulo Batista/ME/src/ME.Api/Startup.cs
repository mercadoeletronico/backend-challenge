using AutoMapper;
using ME.Api.Data;
using ME.Api.Service.Business.Interface;
using ME.Api.Service.Business.Service;
using ME.Api.Service.Handlers;
using ME.Api.Settings.Configuration;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ME.Api
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

            services.AddControllers()
            .AddNewtonsoftJson(x =>
            {
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            var assembly = typeof(PedidoRequestHandler).GetTypeInfo().Assembly;
            services.AddMediatR(assembly);
            services.AddAutoMapper(assembly);


            MEDataBase mEDataBase = MESettings.GetDataBase(MEProjects.Api);
            switch (mEDataBase)
            {
                case MEDataBase.SqlLite:
                    {
                        services.AddDbContext<ApiDbContext>(options =>
                            options.UseSqlite(MESettings.GetConnectionString(MEProjects.Api)));

                    }
                    break;

            }

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Mercado Eletrônico API",
                    Version = "v1",
                    Description = "Platform API REST",
                });
            });



            services.AddScoped<IPedidoService, PedidoService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Platform API v1");
                c.RoutePrefix = string.Empty;
            });

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
