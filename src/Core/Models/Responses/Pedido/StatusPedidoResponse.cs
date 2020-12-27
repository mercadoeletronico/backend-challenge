using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Responses.Pedido
{
    public class StatusPedidoResponse
    {
        #region properties
        public string Pedido { get; set; }
        public List<string> Status { get; set; }
        #endregion

        #region constructors
        public StatusPedidoResponse(string pedido)
        {
            Pedido = pedido;
            Status = new List<string>();
        }
        #endregion
    }
}
