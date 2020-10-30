using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ME.Pedido.Application.DTO;
using ME.Pedido.Domain;
using Microsoft.AspNetCore.Mvc;


namespace ME.Pedido.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _Repo;

        public PedidoController(IPedidoRepository repo)
        {
            _Repo = repo;
        }
        
        [HttpGet]
        public Task<List<Domain.Pedido>> Get()
        {
            return  _Repo.ObterTodos();
        }


        [HttpGet("{id}")]
        public Task <Domain.Pedido> Get(string id)
        {
            return _Repo.ObterPedidoPorId(id);
        }

        // POST api/<PedidoController>
        [HttpPost]
        public IActionResult Post(PedidoPayload value)
        {
            var domainPedido = value.ToDomainPedido();
            if (domainPedido.IsValid())
            {
                if (_Repo.VerificarSePedidoExiste(value.pedido))
                {
                    return StatusCode(409, new { pedido = value.pedido, mensagem = "Pedido já existe." });
                }

                _Repo.Adicionar(domainPedido);
                return StatusCode(201, new { pedido = value.pedido, mensagem = "Cadastrado com sucesso"});
            }
            return StatusCode(400, new { pedido = value.pedido, mensagem = "Pedido Inválido" });
        }

        [HttpPut]
        public IActionResult Put(PedidoPayload value)
        {
            var domainPedido = value.ToDomainPedido();
            if (domainPedido.IsValid())
            {
                if (!_Repo.VerificarSePedidoExiste(value.pedido))
                {
                    return StatusCode(404, new { pedido = value.pedido, mensagem = "Pedido não encontrado." });
                }
                _Repo.Alterar(value.ToDomainPedido());
                return StatusCode(200, new { pedido = value.pedido, mensagem = "Status Alterado com sucesso" });
            }
            return StatusCode(400, new { pedido = value.pedido, mensagem = "Pedido Inválido" });
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete]
        public IActionResult Delete(PedidoPayload value)
        {
            var domainPedido = value.ToDomainPedido();
            if (domainPedido.IsValid())
            {
                if (!_Repo.VerificarSePedidoExiste(value.pedido))
                {
                    return StatusCode(404, new { pedido = value.pedido, mensagem = "Pedido não encontrado." });
                }

                _Repo.Remover(value.ToDomainPedido());
                return StatusCode(200, new { pedido = value.pedido, mensagem = "Removido com sucesso" });
            }
            return StatusCode(400, new { pedido = value.pedido, mensagem = "Pedido Inválido" });

            
        }
    }
}
