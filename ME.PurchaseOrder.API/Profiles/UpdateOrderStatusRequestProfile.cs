using AutoMapper;
using ME.PurchaseOrder.API.Extensions;
using ME.PurchaseOrder.API.Requests;
using ME.PurchaseOrder.Domain.Commands;

namespace ME.PurchaseOrder.API.Profiles
{
    public class UpdateOrderStatusRequestProfile : Profile
    {
        public UpdateOrderStatusRequestProfile()
        {
            CreateMap<UpdateOrderStatusRequest, UpdateOrderStatusCommand>()
                .ForMember(dest => dest.NumberOrder, opt => opt.MapFrom(src => src.Pedido))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToOrderStatus()))
                .ForMember(dest => dest.ApprovedItems, opt => opt.MapFrom(src => src.ItensAprovados))
                .ForMember(dest => dest.ApprovedValue, opt => opt.MapFrom(src => src.ValorAprovado));
        }
    }
}