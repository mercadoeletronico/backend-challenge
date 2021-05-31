using AutoMapper;
using ME.PurchaseOrder.API.Responses;
using ME.PurchaseOrder.Domain.Commands.OrderBase;
using ME.PurchaseOrder.Domain.Models;

namespace ME.PurchaseOrder.API.Profiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemResponse>()
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.Qtd, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<OrderItemCommand, OrderItem>();
        }
    }
}