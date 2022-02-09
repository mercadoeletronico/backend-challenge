using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste_me.Services
{
    public class ContabilizaItensPedido
    {
        public void Verificar(Models.Pedido Pedido, out decimal valorTotal, out int quantidadeItens)
        {
            valorTotal = 0;
            foreach (var item in Pedido.Itens)
            {
                valorTotal += item.PrecoUnitario * item.Quantidade;
            }
            quantidadeItens = Pedido.Itens.Sum(p => p.Quantidade);
        }
    }
}
