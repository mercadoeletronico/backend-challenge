using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ME.Pedido.Domain;
using ME.Pedido.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;


namespace ME.Pedido.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private readonly IPedidoRepository _Repo;

        public StatusController(IPedidoRepository repo)
        {
            _Repo = repo;
        }

        [HttpPost]
        public IActionResult Post(StatusPedidoRequest value)
        {
            var p = _Repo.ObterPedidoPorId(value.pedido).Result;
            if (p != null)
            {
                if (p.Status != value.status)
                {
                    p.Status = value.status;
                    _Repo.AlterarStatus(p);
                }

                if (p.Status == "REPROVADO")
                {
                    return StatusCode(200, new
                    {
                        pedido = value.pedido,
                        status = new List<string> { "REPROVADO" }
                    });
                }
                else
                {
                    var result = p.AvaliarPedido(value.itensAprovados, value.valorAprovado);
                    return StatusCode(200, result);
                }

            }
            else
            {
                return StatusCode(404, new
                {
                    pedido = value.pedido,
                    status = new List<string> { "CODIGO_PEDIDO_INVALIDO" }
                });

            }

        }
    }
}
