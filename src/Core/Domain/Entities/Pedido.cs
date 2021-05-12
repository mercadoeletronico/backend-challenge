using System.Collections.Generic;

namespace Domain.Entities
{
    public class Pedido
    {
        public string NumeroPedido { get; set; }
        public IEnumerable<PedidoItens> PedidoItens { get; set; }

    }
}