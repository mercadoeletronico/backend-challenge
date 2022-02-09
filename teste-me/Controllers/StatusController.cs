using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teste_me.Models;
using teste_me.Models.RequestModels;
using teste_me.Models.ResponseModels;
using teste_me.Repository.Context;
using teste_me.Services;

namespace teste_me.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase 
    {
        private MudancaStatusPedido _mudancaStatusPedido;

        public StatusController(MudancaStatusPedido mudancaStatusPedido)
        {
            _mudancaStatusPedido = mudancaStatusPedido;
        }

        // POST: api/Status
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResponseModelMudancaStatusPedido>> PostStatus(RequestModelMudancaStatusPedido request)
        {
            ResponseModelMudancaStatusPedido response =  await _mudancaStatusPedido.StatusPedido(request);
            return Ok(response);
        }
    }
}
