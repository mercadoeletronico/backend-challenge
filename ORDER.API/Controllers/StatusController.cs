using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ORDER.API.ViewModels;
using ORDER.Application.Dto;
using ORDER.Application.Services.Interfaces;

namespace ORDER.API.Controllers
{
    [ApiController]
    [Route("/api/status")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _service;

        public StatusController(IStatusService statusService)
        {
            _service = statusService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(StatusResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public StatusResponseDto Post([FromBody] StatusRequestDto request)
        {
            return _service.ApprovedStatus(request);
        }
    }
}