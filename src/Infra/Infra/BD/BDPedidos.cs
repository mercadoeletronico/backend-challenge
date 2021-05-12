using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Commands;
using Domain.Notifications;
using model = Domain.Entities;
namespace Infra.BD
{
    public class BDPedidos
    {
        public string IdPedido { get; set; }


        public List<BDItensPedidos> ItensPedido { get; set; }


    }
    public class Banco
    {
        public List<BDPedidos> bdPedido { get; set; }
        public Banco()
        {
            bdPedido = new List<BDPedidos>();
        }
        public bool AdicionarPedido(PedidoCommand pedido)
        {
            var VerificarId = bdPedido.FirstOrDefault(x => x.IdPedido == pedido.NumeroPedido);
            if (VerificarId != null)
            {
                return false;
            }

            var bancobd = new BDPedidos();
            bancobd.IdPedido = pedido.NumeroPedido;

            var itemPedidoList = new List<BDItensPedidos>();

            foreach (var item in pedido.PedidoItens)
            {
                itemPedidoList.Add(new BDItensPedidos
                {
                    Descricao = item.Descricao,
                    PrecoUnitario = item.PrecoUnitario,
                    Quantidade = item.Quantidade
                });
            }
            bancobd.ItensPedido = itemPedidoList;
            bdPedido.Add(bancobd);
            return true;
        }



        public List<model.Pedido> ListarPedidos()
        {
            var modelPedidoList = new List<model.Pedido>();

            foreach (var item in bdPedido)
            {
                var modelPedido = new model.Pedido();
                modelPedido.NumeroPedido = item.IdPedido;
                var ListBdItems = new List<model.PedidoItens>();

                foreach (var itemPedido in item.ItensPedido)
                {
                    ListBdItems.Add(new model.PedidoItens
                    {
                        Descricao = itemPedido.Descricao,
                        PrecoUnitario = itemPedido.PrecoUnitario,
                        Quantidade = itemPedido.Quantidade
                    });
                }
                modelPedido.PedidoItens = ListBdItems;
                modelPedidoList.Add(modelPedido);

            }
            return modelPedidoList;

        }

        public void RemoverPedido(string IdPedido)
        {
            var itemX = bdPedido.FirstOrDefault(x => x.IdPedido == IdPedido);
            bdPedido.Remove(itemX);
        }
        public bool AlterarPedido(PedidoCommand pedido)
        {
            var VerificarId = bdPedido.Where(x => x.IdPedido == pedido.NumeroPedido);
            if (VerificarId.Count() == 0)
            {
                return false;
            }

            RemoverPedido(pedido.NumeroPedido);
            AdicionarPedido(pedido);
            return true;
        }
        public model.Pedido ListarPedidoByID(string idPedido)
        {
           var pedido = ListarPedidos();
           return pedido.FirstOrDefault(c => c.NumeroPedido == idPedido);
        }

    }
}