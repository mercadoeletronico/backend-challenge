using Microsoft.AspNetCore.Mvc;

namespace MercadoEletronico.Aplication.Controllers
{
    public class BaseController : Controller
    {
        private readonly Business.Interfaces.INotificador _Notificador;

        protected BaseController(Business.Interfaces.INotificador notificador)
        {
            _Notificador = notificador;
        }

        protected IActionResult CustomResponse(object result = null)
        {
            if (_Notificador.TemNotificacao())
            {
                string mensagem = _Notificador.ObterNotificacoes()[0].Mensagem;

                return StatusCode(500, mensagem);
            }
            else if (result == null)
                return NoContent();
            else
                return Ok(result);
        }
    }
}
