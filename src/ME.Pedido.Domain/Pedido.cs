using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ME.Core.DomainObjects;
using ME.Pedido.Domain.ValueObjects;

namespace ME.Pedido.Domain
{
    public class Pedido:Entity, IAggregateRoot
    {
        public string PedidoID { get; set; }
        public string Status { get; set; } = "PENDENTE";
        public virtual List<PedidoItem> PedidoItems { get; set; }

        public Pedido(string id, List<PedidoItem> items)
        {
            PedidoID = id;
            PedidoItems = items;
        }

        protected Pedido()
        {
            PedidoItems = new List<PedidoItem>();
        }

        public decimal CalcularValorPedido()
        {
            return PedidoItems.Sum(p => p.CalcularValor());
        }

        public decimal CalcularQuantidade()
        {
            return PedidoItems.Sum(p => p.qtd);
        }

        public StatusPedidoResponse AvaliarPedido(int itensAprovados, decimal valorAprovado)
        {
            var res = new StatusPedidoResponse
            {
                pedido = PedidoID,
                status = new List<string>()
            };
            
            if (itensAprovados == 0 && valorAprovado == 0)
            {
                Status = "REPROVADO";
                res.status.Add("REPROVADO");
                return res;
            }
            
            var valorTotal = CalcularValorPedido();
            var quantidadeTotal = CalcularQuantidade();

            Status = "APROVADO";
            if (quantidadeTotal == itensAprovados && valorTotal == valorAprovado)
            {
                res.status.Add("APROVADO");
                return res;
            }

            if (valorAprovado < valorTotal)
            {
                res.status.Add("APROVADO_VALOR_A_MENOR");
            }
            else if (valorAprovado > valorTotal)
            {
                res.status.Add("APROVADO_VALOR_A_MAIOR");
            }

            if (itensAprovados < quantidadeTotal)
            {
                res.status.Add("APROVADO_QTD_A_MENOR");
            }
            else if (itensAprovados > quantidadeTotal)
            {
                res.status.Add("APROVADO_QTD_A_MAIOR");
            }
            
            return res;
        }


        public override bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(PedidoID)) return false;
            if (PedidoItems.Count == 0) return false;
            foreach (var pedidoItem in PedidoItems)
            {
                if (!pedidoItem.IsValid()) return false;
            }
            return true;
        }


    }
}
