using AutoMapper;
using PedidosME.Domain.PedidoAggregate.Entities;

namespace PedidosME.Domain.DTOs.Mappers
{
    public class DomainMappers : Profile
    {
        public DomainMappers()
        {
            CreateMap<Pedido, PedidoDTO>()
            .ForMember(x => x.Pedido, opt => opt.MapFrom(src => src.Codigo))
            .ForMember(x => x.Itens, opt => opt.MapFrom(src => src.Itens));

            CreateMap<ItemPedido, ItemPedidoDTO>()
                .ForMember(x => x.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(x => x.PrecoUnitario, opt => opt.MapFrom(src => src.PrecoUnitario))
                .ForMember(x => x.Qtd, opt => opt.MapFrom(src => src.Quantidade));

        }
    }
}
