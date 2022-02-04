using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace MercadoEletronico.Aplication.Configuration
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            MapperConfiguration mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiles.MapingPedido());
                mc.AddProfile(new AutoMapperProfiles.MapingPedidoItem());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
