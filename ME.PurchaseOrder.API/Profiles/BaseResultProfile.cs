using AutoMapper;
using FluentValidation.Results;
using ME.PurchaseOrder.API.Responses;
using ME.PurchaseOrder.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ME.PurchaseOrder.API.Profiles
{
    public class BaseResultProfile : Profile
    {
        public BaseResultProfile()
        {
            CreateMap<IEnumerable<ValidationFailure>, BaseResponse>()
                .Include<IEnumerable<ValidationFailure>, OrderStatusResponse>()
                .BeforeMap((src, dest) =>
                {
                    dest.StatusCode = StatusCodes.Status400BadRequest;
                    foreach (var item in src)
                        dest.AddError(item.ErrorCode, item.ErrorMessage);
                });

            CreateMap<IEnumerable<ValidationFailure>, OrderStatusResponse>();

            CreateMap<IEnumerable<Order>, BaseListResponse<OrderSummaryResponse>>()
                .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => StatusCodes.Status200OK));

            CreateMap<Order, OrderSummaryResponse>()
                .ForMember(dest => dest.Pedido, opt => opt.MapFrom(src => src.NumberOrder))
                .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => StatusCodes.Status200OK));
        }
    }
}