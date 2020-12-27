using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Responses.Pedido
{
    public class PedidoResponse
    {
           public string Pedido { get;set; }
           public List<ItemPedidoResponse> Itens { get; set; }
    }
}
