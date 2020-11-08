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
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ListarPedidos { }, cancellationToken));
            }
            catch (Exception error)
            {
                return NotFound(error.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(
            string id, 
            CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ProcurarPedido { Pedido = id }, cancellationToken));
            }
            catch (Exception error)
            {
                return NotFound(error.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] AdicionarPedido request, 
            CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(request, cancellationToken);

                return Ok();
            }
            catch (Exception error)
            {
                return StatusCode(304, error.Message); //NotModified
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(
            [FromBody] AlterarPedido request, 
            CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(request, cancellationToken);

                return Ok();
            }
            catch (Exception error)
            {
                return StatusCode(304, error.Message); //NotModified
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            string id, 
            CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(new RemoverPedido { Pedido = id }, cancellationToken);

                return Ok();
            }
            catch (Exception error)
            {
                return StatusCode(304, error.Message); //NotModified
            }
        }
    }
}
