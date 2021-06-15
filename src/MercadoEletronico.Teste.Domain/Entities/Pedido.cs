using System;
using System.Collections.Generic;
using System.Text;

namespace MercadoEletronico.Teste.Domain.Entities
{
    public class Pedido : Entity
    {
        public IEnumerable<Item> Itens { get; set; }
    }
}