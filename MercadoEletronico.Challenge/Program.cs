using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NerdVision;

namespace MercadoEletronico.Challenge
{
    public class Program
    {

        public static void Main(string[] args)
        {
            NV.Start("nv-Wnl5r07YX2JHmiAUB3bj");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
