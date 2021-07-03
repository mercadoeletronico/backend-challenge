using backend_challenge_datatypes.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Vrnz2.BaseContracts.DTOs.Base.BaseDTO;

namespace backend_challenge.UseCases.GetProducts
{
    public class GetProducts
    {
        //public class Model
        //{
        //    public class Input
        //        : IRequest<Output>
        //    {
        //    }

        //    public class Output
        //        : Response<List<GetProductsResponse>>
        //    {
        //    }
        //}

        //public class Handler
        //    : IRequestHandler<Model.Input, Model.Output>
        //{
        //    #region Variables

        //    private readonly IUnitOfWork _serviceColletion;
        //    private readonly ITokenCacheRepository _tokenCacheRepository;

        //    #endregion

        //    #region Constructors

        //    public Handler()
        //    {
        //        _serviceColletion = serviceColletion;
        //        _tokenCacheRepository = tokenCacheRepository;
        //    }

        //    #endregion

        //    #region Methods

        //    public async Task<Model.Output> Handle(Model.Input request, CancellationToken cancellationToken)
        //    {
        //        var statusCode = HttpStatusCode.OK;
        //        var result = false;

        //        using (var unitOfWork = _serviceColletion.BuildServiceProvider().GetService<IUnitOfWork>())
        //        {
        //            unitOfWork.OpenConnection();

        //            var getUserClaimsRepository = unitOfWork.GetRepository<IGetUserClaimsRepository>(nameof(GetUserClaims));

        //            var myClaims = getUserClaimsRepository.Get("610eb12a-7ee8-40ef-862a-4ba11fe91879", "610eb12a-7ee8-40ef-862a-4ba11fe91879");
        //            var receivedClaims = getUserClaimsRepository.Get("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f", "ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f");
        //            var allClaims = getUserClaimsRepository.Get("610eb12a-7ee8-40ef-862a-4ba11fe91879", "ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f");
        //        }


        //        result = (_tokenCacheRepository.TokenExists(request.token));

        //        if (result)
        //        {
        //            var claims = _tokenCacheRepository.GetValue<List<string>>(request.token);

        //            result = result && claims.Any(t => request.claims.Any(c => c.Equals(t)));

        //            if (!result)
        //                statusCode = HttpStatusCode.Forbidden;
        //        }
        //        else
        //            statusCode = HttpStatusCode.Unauthorized;

        //        return await Task.FromResult(new Model.Output { Success = result, StatusCode = (int)statusCode });
        //    }

        //    #endregion
        //}
    }
}
