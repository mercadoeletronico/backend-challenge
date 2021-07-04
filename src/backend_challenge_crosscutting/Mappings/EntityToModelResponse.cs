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
            CreateMap<Product, GetProductsResponse>()
                .ForMember(d => d.Codigo, orig => orig.MapFrom(src => src.ReferenceCode))
                .ForMember(d => d.Descricao, orig => orig.MapFrom(src => src.Description));
            CreateMap<ViewCustomerFullData, GetCustomersResponse>()
                .ForMember(d => d.Codigo, orig => orig.MapFrom(src => src.Code))
                .ForMember(d => d.Nome, orig => orig.MapFrom(src => src.Name))
                .ForMember(d => d.Ddd, orig => orig.MapFrom(src => src.Ddd))
                .ForMember(d => d.Telefone, orig => orig.MapFrom(src => src.PhoneNumer))
                .ForMember(d => d.Email, orig => orig.MapFrom(src => src.EmailAddress))
                .ForMember(d => d.Cep, orig => orig.MapFrom(src => src.ZipCode))
                .ForMember(d => d.Rua, orig => orig.MapFrom(src => src.Street))
                .ForMember(d => d.Numero, orig => orig.MapFrom(src => src.Number))
                .ForMember(d => d.Cidade, orig => orig.MapFrom(src => src.City))
                .ForMember(d => d.UF, orig => orig.MapFrom(src => src.State))
                ;
            CreateMap<ViewSellerFullData, GetSellersResponse>()
                .ForMember(d => d.Codigo, orig => orig.MapFrom(src => src.Code))
                .ForMember(d => d.Nome, orig => orig.MapFrom(src => src.Name))
                .ForMember(d => d.Ddd, orig => orig.MapFrom(src => src.Ddd))
                .ForMember(d => d.Telefone, orig => orig.MapFrom(src => src.PhoneNumer))
                .ForMember(d => d.Email, orig => orig.MapFrom(src => src.EmailAddress))
                .ForMember(d => d.Cep, orig => orig.MapFrom(src => src.ZipCode))
                .ForMember(d => d.Rua, orig => orig.MapFrom(src => src.Street))
                .ForMember(d => d.Numero, orig => orig.MapFrom(src => src.Number))
                .ForMember(d => d.Cidade, orig => orig.MapFrom(src => src.City))
                .ForMember(d => d.UF, orig => orig.MapFrom(src => src.State))
                ;
        }
    }
}