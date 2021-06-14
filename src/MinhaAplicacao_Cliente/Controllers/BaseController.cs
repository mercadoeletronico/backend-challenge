using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MinhaAplicacao_Cliente.Controllers
{
    public class BaseController : Controller
    {
        protected string _apiBaseUrl;

        public BaseController(IConfiguration configuration)
        {
            this._apiBaseUrl = configuration.GetValue<string>("WebAPIBaseUrl");
        }
    }
}
