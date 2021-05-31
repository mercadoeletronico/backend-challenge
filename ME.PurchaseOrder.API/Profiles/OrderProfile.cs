using AutoMapper;
using ME.PurchaseOrder.API.Responses;
using ME.PurchaseOrder.Domain.Commands;
using ME.PurchaseOrder.Domain.Commands.OrderBase;
using ME.PurchaseOrder.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace ME.PurchaseOrder.API.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderResponse>()
                .ForMember(dest => dest.Pedido, opt => opt.MapFrom(src => src.NumberOrder))
                .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => StatusCodes.Status200OK))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Order, OrderSummaryResponse>()
                .ForMember(dest => dest.Pedido, opt => opt.MapFrom(src => src.NumberOrder))
                .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => StatusCodes.Status200OK))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<OrderCommand, Order>()
                .Include<CreateOrderCommand, Order>()
                .Include<UpdateOrderCommand, Order>();

            CreateMap<CreateOrderCommand, Order>();
            CreateMap<UpdateOrderCommand, Order>();
        }
    }
}