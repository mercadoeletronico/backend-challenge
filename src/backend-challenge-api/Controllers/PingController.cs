using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vrnz2.BaseContracts.DTOs;
using Vrnz2.BaseWebApi.Helpers;

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
            => await _controllerHelper.ReturnAsync((request) => Task.FromResult(new Ping.Response().Content), new Ping.Request());

        #endregion
    }
}
