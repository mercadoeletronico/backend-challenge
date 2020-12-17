using App.Infrastructure.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class BaseController: Controller
    {
        private readonly IUow _uow;

        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        public new async Task<IActionResult> Response(object result)
        {
            try
            {

                await _uow.Commit();
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
            catch (Exception e)
            {
                // Logar o erro ()
                return BadRequest(new
                {
                    success = false,
                    errors = new[] { "Ocorreu uma falha interna no servidor." + e.InnerException.Message }
                });
            }
        }



    }
}
