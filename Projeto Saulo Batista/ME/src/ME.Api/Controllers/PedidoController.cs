using ME.Api.Models.View.Pedido;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ME.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("pedido")]
        public Task<IActionResult> Get(string numPedido)
        {
            var request = new PedidoGetRequest
            {
                NumPedido = numPedido
            };

            var response = _mediator.Send(request);
            return response;
        }


        [HttpGet]
        [Route("pedido/all")]
        public Task<IActionResult> GetAlls(string numPedido)
        {
            var request = new PedidoGetAllRequest
            {
                NumPedido = numPedido
            };

            var response = _mediator.Send(request);
            return response;
        }

        [HttpPost]
        [Route("pedido")]
        public Task<IActionResult> Post(string numPedido)
        {
            var request = new PedidoNewRequest
            {
                NumPedido = numPedido
            };

            var response = _mediator.Send(request);
            return response;
        }

        [HttpPut]
        [Route("pedido")]
        public Task<IActionResult> Put(string numPedido, string novoNumeroPedido)
        {
            var request = new PedidoUpdateRequest
            {
                NumPedido = numPedido,
                NovoNumPedido = novoNumeroPedido
            };

            var response = _mediator.Send(request);
            return response;
        }

        [HttpDelete]
        [Route("pedido")]
        public Task<IActionResult> Delete(string numPedido)
        {
            var request = new PedidoDeleteRequest
            {
                NumPedido = numPedido,

            };

            var response = _mediator.Send(request);
            return response;
        }

        [HttpPost]
        [Route("status")]
        public Task<IActionResult> PostStatus(String status, int itensAprovados, decimal valorAprovado, string numPedido)
        {
            var request = new PedidoStatusRequest
            {
                Status = status,
                ItensAprovados = itensAprovados,
                ValorAprovado = valorAprovado,
                NumPedido = numPedido
            };

            var response = _mediator.Send(request);
            return response;
        }


    }
}
