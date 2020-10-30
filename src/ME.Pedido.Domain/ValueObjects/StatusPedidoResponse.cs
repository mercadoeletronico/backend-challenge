using System.Collections.Generic;

namespace ME.Pedido.Domain.ValueObjects
{
    public class StatusPedidoResponse
    {
        public string pedido { get; set; }
        public List<string> status { get; set; }
        
    }
}
