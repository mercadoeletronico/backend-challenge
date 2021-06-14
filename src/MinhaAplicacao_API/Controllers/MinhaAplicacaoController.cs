using Microsoft.AspNetCore.Mvc;

namespace MinhaAplicacao_API.Controllers
{
    [ApiController, Route("api/v{version:apiVersion}/[controller]")]
    public abstract class MinhaAplicacaoController : ControllerBase
    {
    }
}
