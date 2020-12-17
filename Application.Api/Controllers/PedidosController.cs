using App.Domain.Commands.Handlers;
using App.Domain.Commands.Inputs;
using App.Domain.Repositories;
using App.Infrastructure.Transactions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class PedidosController: BaseController
    {
        private readonly IPedidosRepository _repository;
        private readonly PedidosCommandHandler _handler;
        ICollection<Notification> notify = new List<Notification>();

        public PedidosController(IUow uow, IPedidosRepository repository, PedidosCommandHandler handler) 
            : base(uow)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/Pedido/SalvarPedido")]
        public async Task<IActionResult> Post([FromBody] RegisterPedidosCommand command)
        {
            var data = _handler.Handle(command);
            if (data != null)
                return await Response(data);

            return await Response(data);
        }

        [HttpPut]
        [Route("v1/Pedido/AlterarStatus")]
        public async Task<IActionResult> Put([FromBody] AlterPedidosCommand command)
        {
            var data = _handler.HandleUpdate(command);
            if (data != null)
                return await Response(data);

            return await Response(data);
        }


    }
}
