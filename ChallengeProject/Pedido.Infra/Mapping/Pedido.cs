using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pedido.Infra.Mapping
{
    [Table("Pedido")]
    public class Pedido
    {
        public string NumeroPedido { get; set; }

        public IList<ItemPedido> Itens { get; set; }
    }

}
