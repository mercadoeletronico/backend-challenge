using System.Collections.Generic;

namespace Domain.Entities
{
    public class StatusPedido
    {
        public string Pedido { get; set; }
        public List<string> Status { get; set; }
        
    }
}