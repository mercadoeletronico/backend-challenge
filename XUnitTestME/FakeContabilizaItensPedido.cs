using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste_me.Models;
using teste_me.Services;
using Xunit;

namespace XUnitTestME
{
    public class FakeContabilizaItensPedido
    {
        Pedido pedido;
        ContabilizaItensPedido _contabilizaItensPedido;
        public FakeContabilizaItensPedido()
        {
            _contabilizaItensPedido = new ContabilizaItensPedido();
            pedido = new Pedido()
            {
                ID = 1,
                Itens = new List<Item>()
            {
                new Item()
                {
                    Descricao = "ITEM 1", PrecoUnitario = 10 , Quantidade = 5
                },
                new Item()
                {
                    Descricao = "ITEM 2", PrecoUnitario = 5 , Quantidade = 10
                }
            }

            };
        }

        [Fact]
        public void ContabilizaValorQuantidade()
        {
            decimal valorTotal;
            int quantidadeItem;
            int quantidadeItemTest = pedido.Itens.Sum(p=> p.Quantidade);
            decimal valorTotalTest =0;
            foreach (var item in pedido.Itens)
            {
                valorTotalTest += item.PrecoUnitario * item.Quantidade;
            }
            _contabilizaItensPedido.Verificar(pedido, out valorTotal, out quantidadeItem);
            Assert.Equal(quantidadeItemTest, quantidadeItem);
            Assert.Equal(valorTotalTest, valorTotal);

        }

    }
}
