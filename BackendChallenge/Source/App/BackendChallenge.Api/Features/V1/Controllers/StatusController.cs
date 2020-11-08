using System;
using System.Threading;
using System.Threading.Tasks;

using BackendChallenge.Application.UseCases;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BackendChallenge.Api.Features.V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] AlterarStatusDoPedido request,
            CancellationToken cancellationToken)
        {
            try
            {
                var status = await _mediator.Send(request, cancellationToken);

                return Ok(status);
            }
            catch (Exception error)
            {
                return StatusCode(304, error.Message); //NotModified
            }
        }
    }
}
