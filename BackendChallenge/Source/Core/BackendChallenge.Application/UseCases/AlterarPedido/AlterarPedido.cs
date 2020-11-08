using System.Collections.Generic;
using System.Linq;

using BackendChallenge.Entities;

using MediatR;

namespace BackendChallenge.Application.UseCases
{
    public class AlterarPedido : IRequest
    {
        public string Pedido { get; set; }

        public IEnumerable<AlterarItem> Itens { get; set; }

        public static Order ConverTo(AlterarPedido order)
        {
            return new Order
            {
                Number = order.Pedido,
                Items = order.Itens
                             .Select(s => AlterarItem.ConverTo(s))
                             .ToList()
            };
        }
    }
}
