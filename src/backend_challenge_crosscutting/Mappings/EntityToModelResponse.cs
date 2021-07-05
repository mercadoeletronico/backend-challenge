using AutoMapper;
using backend_challenge_datatypes.Entities;
using backend_challenge_datatypes.Responses;

namespace backend_challenge_crosscutting.Mappings
{
    public class EntityToModelResponse
        : Profile
    {
        public EntityToModelResponse()
        {
            CreateMap<Product, GetProductResponse>()
                .ForMember(d => d.Codigo, orig => orig.MapFrom(src => src.ReferenceCode))
                .ForMember(d => d.Descricao, orig => orig.MapFrom(src => src.Description));

            CreateMap<ViewCustomerFullData, GetCustomerResponse>()
                .ForMember(d => d.Codigo, orig => orig.MapFrom(src => src.Code))
                .ForMember(d => d.Nome, orig => orig.MapFrom(src => src.Name))
                .ForMember(d => d.Ddd, orig => orig.MapFrom(src => src.Ddd))
                .ForMember(d => d.Telefone, orig => orig.MapFrom(src => src.PhoneNumer))
                .ForMember(d => d.Email, orig => orig.MapFrom(src => src.EmailAddress))
                .ForMember(d => d.Cep, orig => orig.MapFrom(src => src.ZipCode))
                .ForMember(d => d.Rua, orig => orig.MapFrom(src => src.Street))
                .ForMember(d => d.Numero, orig => orig.MapFrom(src => src.Number))
                .ForMember(d => d.Cidade, orig => orig.MapFrom(src => src.City))
                .ForMember(d => d.UF, orig => orig.MapFrom(src => src.State));

            CreateMap<ViewSellerFullData, GetSellerResponse>()
                .ForMember(d => d.Codigo, orig => orig.MapFrom(src => src.Code))
                .ForMember(d => d.Nome, orig => orig.MapFrom(src => src.Name))
                .ForMember(d => d.Ddd, orig => orig.MapFrom(src => src.Ddd))
                .ForMember(d => d.Telefone, orig => orig.MapFrom(src => src.PhoneNumer))
                .ForMember(d => d.Email, orig => orig.MapFrom(src => src.EmailAddress))
                .ForMember(d => d.Cep, orig => orig.MapFrom(src => src.ZipCode))
                .ForMember(d => d.Rua, orig => orig.MapFrom(src => src.Street))
                .ForMember(d => d.Numero, orig => orig.MapFrom(src => src.Number))
                .ForMember(d => d.Cidade, orig => orig.MapFrom(src => src.City))
                .ForMember(d => d.UF, orig => orig.MapFrom(src => src.State));

            CreateMap<ViewOrderFullData, GetOrderResponse>()
                .ForMember(d => d.pedido, orig => orig.MapFrom(src => src.Number));

            CreateMap<ViewOrderItemFullData, GetOrderItemResponse>()
                .ForMember(d => d.codigoProduto, orig => orig.MapFrom(src => src.ProductReferenceCode))
                .ForMember(d => d.descricao, orig => orig.MapFrom(src => src.ProductDescription))
                .ForMember(d => d.precoUnitario, orig => orig.MapFrom(src => src.UnitaryValue))
                .ForMember(d => d.qtd, orig => orig.MapFrom(src => src.Quantity));
        }
    }
}