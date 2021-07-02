using backend_challenge_data.Migrations;
using backend_challenge_infra.Settings;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;
using Vrnz2.BaseInfra.Assemblies;
using Vrnz2.BaseInfra.Logs;
using Vrnz2.BaseInfra.Settings;
using Vrnz2.BaseInfra.Validations;
using Vrnz2.BaseWebApi.Helpers;
using Vrnz2.BaseWebApi.Validations;
using Vrnz2.Infra.Data.Migrations;
using Vrnz2.Infra.Repository.Settings;

namespace backend_challenge
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
            services
                .AddControllers()
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
                .AddFluentValidation();

            services
                .AddSettings(out AppSettings appSettings)
                .AddSettings<ConnectionStrings>("ConnectionStrings")
                .AddLogs()
                .CreatePostgresDatabase(Constants.DbName, GetOwnerConnectionString(appSettings))
                .ConfigPostgresMigrations(AssembliesHelper.GetAssemblies<CreateDatabase>(), GetDefaultConnectionString(appSettings))                
                .AddBaseValidations()
                .AddValidation<Vrnz2.BaseContracts.DTOs.Ping.Request, PingRequestValidator>()
                .AddScoped<ControllerHelper>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "backend_challenge", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "backend_challenge v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private string GetOwnerConnectionString(AppSettings appSettings)
        {
            var connectionString = appSettings.ConnectionStrings.ConnectionsStrings.SingleOrDefault(s => Constants.OwnerConnectinStringName.Equals(s.Name));

            return connectionString.Value;
        }

        private string GetDefaultConnectionString(AppSettings appSettings)
        {
            var connectionString = appSettings.ConnectionStrings.ConnectionsStrings.SingleOrDefault(s => Constants.DbName.Equals(s.Name));

            return connectionString.Value;
        }
    }
}
