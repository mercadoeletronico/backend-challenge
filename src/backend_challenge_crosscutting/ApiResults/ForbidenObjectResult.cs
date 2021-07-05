using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace backend_challenge_crosscutting.ApiResults
{
    public class ForbidenObjectResult
        : ObjectResult
    {
        public ForbidenObjectResult(ModelStateDictionary modelState)
            : base(modelState)
        {
            StatusCode = (int)HttpStatusCode.Forbidden;
        }

        public ForbidenObjectResult(object error)
            : base(error)
        {
            StatusCode = (int)HttpStatusCode.Forbidden;
        }
    }
}
