using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Commands.Pedido;
using Core.Models.Requests.Pedido;
using Core.Queries.Pedido;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PedidoController : ControllerBase
    {
        #region propperties
        private readonly IMediator _mediator;
        private readonly ILogger<PedidoController> _logger;
        #endregion

        #region constructor
        public PedidoController(IMediator mediator, ILogger<PedidoController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }
        #endregion

        #region calls pedido
        [AllowAnonymous]
        [HttpPost("pedido")]
        public async Task<IActionResult> CreatePedido([FromBody] SavePedidoRequest savePedidoRequest)
        {
            var command = new CreatePedidoCommand(savePedidoRequest);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPut("pedido/{codigo}")]
        public async Task<IActionResult> UpdatePedido(string codigo,[FromBody] SavePedidoRequest savePedidoRequest)
        {
            savePedidoRequest.Codigo = codigo;
            var command = new UpdatePedidoCommand(savePedidoRequest);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("pedido")]
        public async Task<IActionResult> GetPedido()
        {
            var query = new GetPedidoQuery();
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpDelete("pedido/{codigo}")]
        public async Task<IActionResult> DeletePedido(string codigo)
        {
            DeletePedidoRequest request = new DeletePedidoRequest(codigo);
            var command = new DeletePedidoCommand(request);
            var response = await _mediator.Send(command);

            return Ok(response);
        }
        #endregion

        #region calls status pedido


        [AllowAnonymous]
        [HttpPost("status")]
        public async Task<IActionResult> GetStatusPedido([FromBody] StatusPedidoRequest statusPedidoRequest)
        {
            var query = new GetStatusPedidoQuery(statusPedidoRequest);
            var response = await _mediator.Send(query);

            return Ok(response);
        }    
        #endregion
    }
}
