using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Responses.Pedido
{
    public class ItemPedidoResponse
    {
        public long ItemPedidoId { get; set; }
        public long PedidoId { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
