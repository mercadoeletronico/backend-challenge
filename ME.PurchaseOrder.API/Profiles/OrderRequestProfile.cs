using AutoMapper;
using ME.PurchaseOrder.API.Requests;
using ME.PurchaseOrder.Domain.Commands;
using ME.PurchaseOrder.Domain.Commands.OrderBase;

namespace ME.PurchaseOrder.API.Profiles
{
    public class OrderRequestProfile : Profile
    {
        public OrderRequestProfile()
        {
            CreateMap<OrderRequest, OrderCommand>()
                .Include<OrderRequest, CreateOrderCommand>()
                .Include<OrderRequest, UpdateOrderCommand>()
                .ForMember(src => src.NumberOrder, opt => opt.MapFrom(dest => dest.Pedido))
                .ForMember(src => src.Items, opt => opt.MapFrom(dest => dest.Itens));

            CreateMap<OrderRequest, CreateOrderCommand>();

            CreateMap<OrderRequest, UpdateOrderCommand>();
        }
    }
}