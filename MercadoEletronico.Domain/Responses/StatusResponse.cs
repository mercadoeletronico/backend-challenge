using System.Collections.Generic;

namespace MercadoEletronico.Domain.Responses
{
    public class StatusResponse
    {
        public StatusResponse()
        {
            Status = new List<string>();
        }

        public int Pedido { get; set; }

        public List<string> Status { get; set; }
    }
}