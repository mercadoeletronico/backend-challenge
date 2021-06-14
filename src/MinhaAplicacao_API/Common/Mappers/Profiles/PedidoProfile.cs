using AutoMapper;
using MinhaAplicacao.Dominio.Entidades;

namespace MinhaAplicacao_API.Common.Mappers.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            this.CreateMap<Pedido, V1.Models.PedidoModel>().ReverseMap();
        }
    }
}
