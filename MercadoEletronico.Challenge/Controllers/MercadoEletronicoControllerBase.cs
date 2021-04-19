using MercadoEletronico.Challenge.Util;
using Microsoft.AspNetCore.Mvc;

namespace MercadoEletronico.Challenge.Controllers
{
    public class MercadoEletronicoControllerBase : ControllerBase
    {
        private const string NullErrorMessage = "Something went wrong, please check logs for details";

        protected IActionResult StructuredResponse<T>(Result<T> result) 
        {
            if (result is null)
            {
                return StatusCode(500, NullErrorMessage);
            }

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Content),
                ResultStatus.NoContent => NoContent(),
                ResultStatus.BadRequest => BadRequest(result.Notifications),
                ResultStatus.Unauthorized => Unauthorized(),
                _ => StatusCode(500, result.Notifications),
            };
        }

        protected IActionResult StructuredResponse(Result result)
        {
            if (result is null)
            {
                return StatusCode(500, NullErrorMessage);
            }

            return result.Status switch
            {
                ResultStatus.Success => Ok(),
                ResultStatus.NoContent => NoContent(),
                ResultStatus.BadRequest => BadRequest(result.Notifications),
                ResultStatus.Unauthorized => Unauthorized(),
                _ => StatusCode(500, result.Notifications),
            };
        }
    }
}
