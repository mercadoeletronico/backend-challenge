using AutoMapper;
using PedidosME.Domain.PedidoAggregate.Entities;
using PedidosME.Mappers.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosME.Mappers
{
    public class DomainTODTOs : Profile
    {
        public DomainTODTOs()
        {
            CreateMap<Pedido, PedidoDTO>()
                .ForMember(x => x.Pedido, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(x => x.Itens, opt=> opt.MapFrom(src=>  src.Itens));

            CreateMap<ItemPedido, ItemPedidoDTO>()
                .ForMember(x => x.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(x => x.PrecoUnitario, opt => opt.MapFrom(src => src.PrecoUnitario))
                .ForMember(x => x.Qtd, opt => opt.MapFrom(src => src.Quantidade));
            

        }
    }
}
