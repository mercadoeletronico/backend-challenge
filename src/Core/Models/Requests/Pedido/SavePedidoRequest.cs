using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Requests.Pedido
{
    public class SavePedidoRequest
    {
        public string Codigo { get; set; }
        public List<SaveItemRequest> Itens { get; set; }

    }
}
