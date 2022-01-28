using Microsoft.AspNetCore.Mvc;
using ORDER.Domain.Dto;
using ORDER.Domain.Services;

namespace ORDER.API.Controllers
{
    [ApiController]
    [Route("[controller]/api/status")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _service;

        public StatusController(IStatusService statusService)
        {
            _service = statusService;
        }

        [HttpPost]
        public StatusResponseDto Post([FromBody] StatusRequestDto request)
        {
            return _service.ApprovedStatus(request);
        }
    }
}