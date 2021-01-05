using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pedido.Infra.Mapping
{
    public class ItemPedido
    {
        public string Descricao { get; set; }

        public decimal PrecoUnitario { get; set; }

        public int Quantidade { get; set; }
    }
}
