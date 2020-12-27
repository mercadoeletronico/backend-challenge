using Core.Enums;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Pedido
{
    [Table("ItemPedido")]
    public class ItemPedido
    {
        [Key]
        public long ItemPedidoId { get; set; }
        public long PedidoId  { get; set; }
        public string Descricao { get; set; }
        public double PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        [Write(false)]
        public virtual double Valor { get { return PrecoUnitario * Quantidade;  } }

    }
}
