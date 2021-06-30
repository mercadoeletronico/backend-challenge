using AutoMapper;
using BackendChallenge.Api.Model.Request;
using BackendChallenge.Api.Model.Response;
using BackendChallenge.Core.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace BackendChallenge.Api.Configurations
{
    public static class AutoMapperConfigurations
    {
        public static IServiceCollection AddAutoMapperConfigurations(this IServiceCollection services)
        {
            var config = AutoMapperConfigurations.GetMapperConfiguration();
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static MapperConfiguration GetMapperConfiguration()
        {
            return new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderResponse>()
                    .ForMember(dest => dest.Pedido, opt => opt.MapFrom(src => src.Id.ToString()));

                cfg.CreateMap<Item, ItemResponse>()
                    .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.Price))
                    .ForMember(dest => dest.Qtd, opt => opt.MapFrom(src => src.Quantity));

                cfg.CreateMap<NewOrderRequest, Order>();

                cfg.CreateMap<NewItemRequest, Item>()
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Descricao))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PrecoUnitario))
                    .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Qtd));
            });
        }
    }
}
