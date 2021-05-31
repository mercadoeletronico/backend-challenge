using ME.PurchaseOrder.API.Configurations;
using ME.PurchaseOrder.Domain.Configurations;
using ME.PurchaseOrder.Infra.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace ME.PurchaseOrder.API
{
    public class Startup
    {
        private const string PolicyApi = "PolicyApi";

        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRepositoryDependencies();
            services.AddDomainDependencies();
            services.AddApplicationDependencies();

            services.ConfigurarHealthChecks();

            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ME.PurchaseOrder.API", Version = "v1" });
                });

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddCors(opt =>
                {
                    opt.AddPolicy(name: PolicyApi,
                        builder => builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .WithHeaders(HeaderNames.ContentType, "application/json")
                        );
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ME.PurchaseOrder.API v1"));
            }

            app.UseHealthCheckExtension();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                    .RequireCors(PolicyApi);
            });
        }
    }
}