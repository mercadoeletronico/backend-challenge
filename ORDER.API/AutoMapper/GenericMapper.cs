using AutoMapper;
using ORDER.Domain.Dto;
using ORDER.Domain.Entities;

namespace ORDER.API.AutoMapper
{
    public class GenericMapper : Profile
    {
        public GenericMapper()
        {
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}