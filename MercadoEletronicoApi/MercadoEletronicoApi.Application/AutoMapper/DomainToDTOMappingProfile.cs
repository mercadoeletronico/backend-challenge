using AutoMapper;
using MercadoEletronicoApi.Application.DTOs;
using MercadoEletronicoApi.Domain.Entities;

namespace MercadoEletronicoApi.Application.AutoMapper
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Item, ItemDTO>().ReverseMap();
        }
    }
}
