using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Requests.Pedido
{
    public class SaveItemRequest
    {
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }        
    }
}
