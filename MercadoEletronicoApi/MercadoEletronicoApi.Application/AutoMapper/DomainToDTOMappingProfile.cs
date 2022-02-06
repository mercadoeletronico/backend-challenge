using AutoMapper;
using MercadoEletronicoApi.Application.DTOs;
using MercadoEletronicoApi.Domain.Entities;

namespace MercadoEletronicoApi.Application.AutoMapper
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Pedido, PedidoDTO>().ReverseMap();
            CreateMap<Item, ItemDTO>().ReverseMap();
        }
    }
}
