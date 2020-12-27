using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Responses.Pedido
{
    public class DeletePedidoResponse
    {
        public bool OK { get; set; }
        public DeletePedidoResponse(bool ok)
        {
            OK = ok;
        }
    }
}
