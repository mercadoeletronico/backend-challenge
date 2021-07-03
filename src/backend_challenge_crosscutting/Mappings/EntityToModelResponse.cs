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
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<Payment, GetPaymentModel.ResponsePayments>();
            //});

            //var mapper = config.CreateMapper();

            CreateMap<Product, GetProductsResponse>();
            CreateMap<ViewCustomerFullData, GetCustomersResponse>();
            CreateMap<ViewSellerFullData, GetSellersResponse>();
            //CreateMap<List<Payment>, List<GetPaymentModel.ResponsePayments>>()
            //    .ConvertUsing(ss => ss.Select(bs => mapper.Map<Payment, GetPaymentModel.ResponsePayments>(bs)).ToList());
            //CreateMap<List<Payment>, GetPaymentModel.Response>()
            //    .ForMember(d => d.Payments, orig => orig.MapFrom(src => src));
        }
    }
}
