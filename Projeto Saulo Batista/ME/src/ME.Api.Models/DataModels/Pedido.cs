using ME.Api.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ME.Api.Models.DataModels
{
    public class Pedido
    {
        public int Id { get; set; }
        public String NumPedido { get; set; }
        public List<ItemPedido> Itens { get; set; }

    }
}
