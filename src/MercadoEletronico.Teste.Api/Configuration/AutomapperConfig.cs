using AutoMapper;
using MercadoEletronico.Teste.Api.ViewModels;
using MercadoEletronico.Teste.Domain.Entities;

namespace MercadoEletronico.Teste.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Pedido, PedidoViewModel>().ReverseMap();
            CreateMap<Item, ItemViewModel>().ReverseMap();
        }
    }
}