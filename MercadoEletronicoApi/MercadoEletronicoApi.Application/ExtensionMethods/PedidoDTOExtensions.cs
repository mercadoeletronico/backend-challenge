using MercadoEletronicoApi.Application.DTOs;
using MercadoEletronicoApi.Domain.Entities;
using System.Collections.Generic;

namespace MercadoEletronicoApi.Application.ExtensionMethods
{
    public static class PedidoDTOExtensions
    {
        public static PedidoDTO ToPedidoDTO(this Pedido pedido) 
        {
            PedidoDTO pedidoDTO = new PedidoDTO();

            pedidoDTO.Id = pedido.Id;

            foreach (var item in pedido.Items)
            {
                pedidoDTO.Items.Add( new ItemDTO 
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    PrecoUnitario = item.PrecoUnitario,
                    Quantidade = item.Quantidade,
                    PedidoId = item.PedidoId.Value
                });
            }

            return pedidoDTO;
        }

    }
}
