using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PedidosME.Domain.DTOs;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PedidosME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        
        private readonly IMediator mediator;
        private readonly ILogger<PedidoController> logger;

        public PedidoController( IMediator mediator, ILogger<PedidoController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(string id, CancellationToken cancellationToken)
        {
            var request = new ConsultarPedidoDTO() { CodigoPedido = id };
            
            var response = await mediator.Send(request, cancellationToken);
            
            if (response == null) return NoContent();

            return Ok(response);
            
            
        }




        [HttpPost("status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DefinirStatus([FromBody] AtualizarStatusDTO statusDTO, 
            CancellationToken cancellationToken)
        {

            var response = await mediator.Send(statusDTO, cancellationToken);
            return Ok(response);
        }

        
    }
}
