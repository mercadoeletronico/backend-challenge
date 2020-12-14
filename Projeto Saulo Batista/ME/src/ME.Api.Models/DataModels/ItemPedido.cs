using System;
using System.Collections.Generic;
using System.Text;

namespace ME.Api.Models.DataModels
{
    public class ItemPedido
    {

        public int Id { get; set; }
        public String Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public Int32 Quantidade { get; set; }

        public virtual int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }

    }
}
