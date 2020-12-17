using App.Domain.Commands.Inputs;
using App.Domain.Commands.Results;
using App.Domain.Entities;
using App.Domain.Repositories;
using App.Shared.Commands;
using System;

namespace App.Domain.Commands.Handlers
{
    public class PedidosCommandHandler : ICommandHandler<RegisterPedidosCommand>
    {
        private readonly IPedidosRepository _repository;

        public PedidosCommandHandler(IPedidosRepository repository)
        {
            _repository = repository;
        }


        public ICommandResult Handle(RegisterPedidosCommand command)
        {
            var commandObject = new Pedido(command.Pedido);
            foreach (var item in command.Itens)
            {
                var itemPedido = new ItensPedido(item.Descricao, item.PrecoUnitario, item.Qtd, command.Pedido);
                commandObject.AddItem(itemPedido);
            }

            _repository.Save(commandObject);
            return new RegisterPedidosCommandResult(commandObject.CodigoPedido, commandObject.Itens);

        }

        public ICommandResult HandleUpdate(AlterPedidosCommand command)
        {
            return new AlterPedidosCommandResult(command.Pedido, command.Status);
        }

    }
}
