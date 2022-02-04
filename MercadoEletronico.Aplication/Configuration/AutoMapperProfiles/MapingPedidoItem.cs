using AutoMapper;

namespace MercadoEletronico.Aplication.Configuration.AutoMapperProfiles
{
    public class MapingPedidoItem : Profile
    {
        public MapingPedidoItem()
        {
            CreateMap<Domain.Entities.PedidoItem, Domain.Requests.PedidoItemRequest>();
            CreateMap<Domain.Requests.PedidoItemRequest, Domain.Entities.PedidoItem>();
        }
    }
}
