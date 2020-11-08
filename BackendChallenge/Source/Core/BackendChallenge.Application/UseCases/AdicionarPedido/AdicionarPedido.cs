using System.Collections.Generic;
using System.Linq;

using BackendChallenge.Entities;

using MediatR;

namespace BackendChallenge.Application.UseCases
{
    public class AdicionarPedido : IRequest
    {
        public string Pedido { get; set; }

        public IEnumerable<AdicionarItem> Itens { get; set; }

        public static Order ConvertTo(AdicionarPedido order)
        {
            return new Order
            {
                Number = order.Pedido,
                Items = order.Itens
                             .Select(s => AdicionarItem.ConverTo(s))
                             .ToList()
            };
        }
    }
}
