using ME.Api.Models.DataModels;
using ME.Api.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ME.Api.Models.View.Pedido
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public String NumPedido { get; set; }
        public List<ItemPedido> Itens { get; set; }
    }
}
