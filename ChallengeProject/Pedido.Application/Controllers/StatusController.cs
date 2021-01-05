using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedido.Domain.Services;

namespace Pedido.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }


        // POST: api/Pedido/PostPedido
        /// <summary>
        /// Creates a Pedido.
        /// </summary>
        /// <remarks>
        [HttpPost]
        public async Task<ActionResult<Domain.Models.PedidoStatusResponse>> Status(Domain.Models.PedidoStatusRequest status)
        {
            var pedidoStatus = await _statusService.MudarSituacaoPedido(status);

            return pedidoStatus;
        }
    }
}