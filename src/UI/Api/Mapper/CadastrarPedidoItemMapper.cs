using System.Collections.Generic;
using Api.Models.Request;
using Domain.Entities;

namespace Api.Mapper
{
    public static class CadastrarPedidoItemMapper
    {
        public static IEnumerable<PedidoItens> Map(this PedidosRequest pedido)
        {

            var pedidosItens = new List<PedidoItens>();
            foreach (var item in pedido.Itens)
            {
                pedidosItens.Add(new PedidoItens
                {
                    Descricao = item.Descricao,
                    PrecoUnitario = item.PrecoUnitario,
                    Quantidade = item.Qtd
                });
            }
            return pedidosItens;
        }
    }
}