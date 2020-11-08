using System.Collections.Generic;
using System.Linq;

using BackendChallenge.Entities;

namespace BackendChallenge.Application.UseCases
{
    public class PedidoEncontrado
    {
        public string Pedido { get; set; }

        public IEnumerable<ItemEncontrado> Itens { get; set; }

        public static PedidoEncontrado ConvertFrom(Order order)
        {
            if (order == null)
            {
                throw new KeyNotFoundException("Pedido não encontrado.");
            }

            return new PedidoEncontrado
            {
                Pedido = order.Number,
                Itens = order.Items.Select(s => ItemEncontrado.ConvertFrom(s))
            };
        }
    }
}
