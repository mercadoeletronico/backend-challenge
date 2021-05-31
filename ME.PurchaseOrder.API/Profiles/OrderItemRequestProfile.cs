using AutoMapper;
using ME.PurchaseOrder.API.Requests;
using ME.PurchaseOrder.Domain.Commands.OrderBase;

namespace ME.PurchaseOrder.API.Profiles
{
    public class OrderItemRequestProfile : Profile
    {
        public OrderItemRequestProfile()
        {
            CreateMap<OrderItemRequest, OrderItemCommand>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.PrecoUnitario))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Qtd));
        }
    }
}