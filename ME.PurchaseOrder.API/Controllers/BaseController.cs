using ME.PurchaseOrder.API.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ME.PurchaseOrder.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
        private readonly string MensagemErroPadrao = "An error occurred while processing the request.Please try again later.";

        public BaseController()
        {
        }

        protected async Task<IActionResult> TratarResultadoAsync(Func<Task<IActionResult>> service)
        {
            try
            {
                return await service();
            }
            catch
            {
                //TODO: Event Sourcing
                var response = new BaseResponse();
                response.AddError(Domain.Enums.ErrorCode.CriticalError, MensagemErroPadrao);

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}