using backend_challenge_crosscutting.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Vrnz2.BaseContracts.DTOs;

namespace backend_challenge.Controllers
{
    [Route("")]
    public class PingController
        : Controller
    {
        #region Variables

        private readonly ControllerHelper _controllerHelper;

        #endregion 

        #region Constructors

        public PingController(ControllerHelper controllerHelper)
            => _controllerHelper = controllerHelper;

        #endregion 

        #region Methods

        /// <summary>
        /// Service Heart Beat end point
        /// </summary>
        /// <returns>DateTime.UtcNow + Service Name</returns>
        [HttpGet("ping")]
        [ProducesResponseType(typeof(PingResponse), 200)]
        public async Task<ObjectResult> Ping()
            => await _controllerHelper.ReturnAsync<Ping.Request, Ping.Response, PingResponse>((request) => Task.FromResult(new Ping.Response { Success = true, StatusCode = (int)HttpStatusCode.OK }), new Ping.Request());

        #endregion
    }
}
