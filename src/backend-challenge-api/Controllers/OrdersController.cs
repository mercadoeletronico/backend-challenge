using backend_challenge_crosscutting.Helpers;
using backend_challenge_datatypes.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Vrnz2.BaseContracts.DTOs.Base;
using backend_challenge.UseCases.GetOrders;
using backend_challenge.UseCases.AddOrder;

namespace backend_challenge.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    public class OrdersController 
        : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(BaseDTO.Response<List<GetOrderResponse>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get([FromServices] ControllerHelper controllerHelper, [FromServices] IMediator mediator)
        {
            var request = new GetOrders.Model.Input();

            return await controllerHelper.ReturnAsync<GetOrders.Model.Input, GetOrders.Model.Output, List<GetOrderResponse>>((request) => mediator.Send(new GetOrders.Model.Input()), request);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseDTO.Response<GetOrderResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromServices] ControllerHelper controllerHelper, [FromServices] IMediator mediator, [FromBody] AddOrder.Model.Input request)
            => await controllerHelper.ReturnAsync<AddOrder.Model.Input, AddOrder.Model.Output, GetOrderResponse>((request) => mediator.Send(request), request);
    }
}
