using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ME.Pedido.Domain;

namespace ME.Pedido.Application.DTO
{
    public class PedidoPayload
    {
        public string pedido { get; set; }  
        public List<PedidoItem> itens { get; set; }


        public Domain.Pedido ToDomainPedido()
        {
            foreach (var i in itens)
            {
                i.PedidoID = pedido;
            }
            return new Domain.Pedido(pedido, itens);
        }
    }
}
