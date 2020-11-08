using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosME.Domain.DTOs
{
    public class PedidoDTO
    {
        public string Pedido { get; set; }
        public IEnumerable<ItemPedidoDTO> Itens { get; set; }
    }

    public class ItemPedidoDTO
    {
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public float Qtd { get; set; }
    }
}
