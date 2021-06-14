using Microsoft.AspNetCore.Mvc;

namespace MinhaAplicacao_Cliente.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
