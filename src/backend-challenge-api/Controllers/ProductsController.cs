using backend_challenge_crosscutting.Helpers;
using backend_challenge_datatypes.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using static backend_challenge.UseCases.GetProducts.GetProducts;

namespace backend_challenge.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController 
        : ControllerBase
    {
        [HttpGet]
        //[ProducesResponseType(typeof(Model.Output), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get([FromServices] ControllerHelper controllerHelper, [FromServices] IMediator mediator)
        {
            var request = new Model.Input();

            return await controllerHelper.ReturnAsync<Model.Input, Model.Output, List<GetProductsResponse>>((request) => mediator.Send(new Model.Input()), request);
        }
    }
}
