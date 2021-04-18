using MercadoEletronico.Challenge.Util;
using Microsoft.AspNetCore.Mvc;

namespace MercadoEletronico.Challenge.Controllers
{
    public class MercadoEletronicoControllerBase : ControllerBase
    {
        protected IActionResult StructuredResponse<T>(Result<T> result) 
        {
            if (result is null)
            {
                return StatusCode(500, "Something went wrong, please check logs for details");
            }

            switch (result.Status) 
            {
                case ResultStatus.Success:
                    return Ok(result.Content);

                case ResultStatus.NoContent:
                    return NoContent();

                case ResultStatus.BadRequest:
                    return BadRequest(result.Notifications);

                case ResultStatus.Unauthorized:
                    return Unauthorized();

                default:
                    return StatusCode(500, result.Notifications);
            }
        }

        protected IActionResult StructuredResponse(Result result)
        {
            if (result is null)
            {
                return StatusCode(500, "Something went wrong, please check logs for details");
            }

            switch (result.Status)
            {
                case ResultStatus.Success:
                    return Ok();

                case ResultStatus.NoContent:
                    return NoContent();

                case ResultStatus.BadRequest:
                    return BadRequest(result.Notifications);

                case ResultStatus.Unauthorized:
                    return Unauthorized();

                default:
                    return StatusCode(500, result.Notifications);
            }
        }
    }
}
