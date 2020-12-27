using AutoMapper;
using System;
using Core.Entities.Pedido;
using Core.Models.Responses.Pedido;
using Core.Models.Requests.Pedido;
using System.Collections;
using System.Collections.Generic;

namespace Core.Mapping
{
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            #region mapper request
            CreateMap<SavePedidoRequest, Pedido>()
                .ForMember(dest => dest.Codigo, src => src.MapFrom(m => m.Codigo));

            CreateMap<SaveItemRequest, ItemPedido>();
            #endregion

            #region mapper reponse
            CreateMap<Pedido, PedidoResponse>()
                .ForMember(dest => dest.Pedido, src => src.MapFrom(m => m.Codigo));

            CreateMap<ItemPedido, ItemPedidoResponse>();
            #endregion
        }

    }
}