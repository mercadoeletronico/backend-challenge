using MercadoEletronicoApi.Application.DTOs;
using MercadoEletronicoApi.Domain.Entities;
using System.Collections.Generic;

namespace MercadoEletronicoApi.Application.ExtensionMethods
{
    public static class PedidoExtensions
    {
        public static Pedido ToPedido(this PedidoDTO pedidoDTO)
        {
            Pedido pedido = new Pedido();

            foreach (var item in pedidoDTO.Items)
            {
                pedido.Items = new List<Item>()
                {
                    new Item()
                    {
                        Descricao = item.Descricao,
                        Quantidade = item.Quantidade,
                        PrecoUnitario = item.PrecoUnitario,
                    }
                };
                #region do jeito abaixo também funciona desde que a lista Items da classe Pedidos esteja inicializada:
                //pedido.Items.Add(new Item()
                //{
                //    Descricao = item.Descricao,
                //    Quantidade = item.Quantidade,
                //    PrecoUnitario = item.PrecoUnitario,
                //});
                #endregion
            }
            return pedido;
        }
    }
}
