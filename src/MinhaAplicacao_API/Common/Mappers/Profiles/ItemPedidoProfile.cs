using AutoMapper;
using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao_API.V1.Models;

namespace MinhaAplicacao_API.Common.Mappers.Profiles
{
    public class ItemPedidoProfile : Profile
    {
        public ItemPedidoProfile()
        {
            this.CreateMap<ItemPedido, ItemPedidoModel>().ReverseMap();
        }
    }
}
