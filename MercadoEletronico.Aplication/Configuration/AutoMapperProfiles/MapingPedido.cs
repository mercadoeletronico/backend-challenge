using AutoMapper;

namespace MercadoEletronico.Aplication.Configuration.AutoMapperProfiles
{
    public class MapingPedido : Profile
    {
        public MapingPedido()
        {
            CreateMap<Domain.Entities.Pedido, Domain.Requests.PedidoRequest>().ForMember(dest => dest.Pedido, opt => opt.MapFrom(src => src.Id));
            CreateMap<Domain.Requests.PedidoRequest, Domain.Entities.Pedido>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Pedido));
        }
    }
}
