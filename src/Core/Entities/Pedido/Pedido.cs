using AutoMapper.Configuration.Annotations;
using Dapper.Contrib.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Entities.Pedido
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        public long PedidoId { get; set; }
        public string Codigo { get; set; }
        [Write(false)]
        public virtual IList<ItemPedido>Itens{ get;set;}
    }
}
