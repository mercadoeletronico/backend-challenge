using System.Collections.Generic;

namespace MercadoEletronico.Challenge.Domain.Models.Responses
{
    public class StatusResponse
    {
        public StatusResponse()
        {
            Status = new List<string>();
        }

        public string Pedido { get; set; }
        public List<string> Status { get; set; }
    }
}
