using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.Domain.Models
{
    public class ItemPedido
    {
        public ItemPedido()
        {

        }
        public long Id { get; set; }

        public string Descricao { get; set; }

        public decimal PrecoUnitario { get; set; }

        public int Quantidade { get; set; }

        public Pedido Pedido { get; set; }

        public long IdPedido { get; set; }
    }
}
