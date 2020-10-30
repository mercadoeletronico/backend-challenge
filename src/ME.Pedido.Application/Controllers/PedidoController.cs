using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ME.Pedido.Application.DTO;
using ME.Pedido.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public void Post(PedidoPayload value)
        {
            _Repo.Adicionar(value.ToDomainPedido());
        }

        [HttpPut]
        public void Put(PedidoPayload value)
        {
            _Repo.AlterarStatus(value.ToDomainPedido());
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete]
        public void Delete(PedidoPayload value)
        {
            _Repo.Remover(value.ToDomainPedido());
        }
    }
}
