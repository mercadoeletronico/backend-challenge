using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;

namespace ME.PurchaseOrder.API.Configurations
{
    public static class HealthCheckConfiguration
    {
        public static IServiceCollection ConfigurarHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks();

            return services;
        }

        public static IApplicationBuilder UseHealthCheckExtension(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/status",
               new HealthCheckOptions
               {
                   ResponseWriter = async (context, report) =>
                   {
                       var result = JsonSerializer.Serialize(
                           new
                           {
                               statusApplication = report.Status.ToString(),
                               healthChecks = report.Entries.Select(e => new
                               {
                                   check = e.Key,
                                   ErrorMessage = e.Value.Exception?.Message,
                                   status = e.Value.Status.ToString()
                               })
                           });
                       context.Response.ContentType = MediaTypeNames.Application.Json;
                       await context.Response.WriteAsync(result);
                   }
               });

            return app;
        }
    }
}