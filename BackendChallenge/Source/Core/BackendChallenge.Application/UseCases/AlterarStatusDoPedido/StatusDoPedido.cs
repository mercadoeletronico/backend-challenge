using System.Collections.Generic;

namespace BackendChallenge.Application.UseCases
{
    public class StatusDoPedido
    {
        public string Pedido { get; set; }

        public IEnumerable<string> Status { get; set; }
    }
}
