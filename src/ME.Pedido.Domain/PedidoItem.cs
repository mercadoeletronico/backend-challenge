using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ME.Core.DomainObjects;

namespace ME.Pedido.Domain
{
    public class PedidoItem : Entity
    {
        public Guid Id { get; set; }
        public string descricao { get; set; }
        public int precoUnitario { get; set; }
        public int qtd { get; set; }

        public string PedidoID { get; set; }
        

        protected PedidoItem()
        {
            Id = Guid.NewGuid();
        }

        public PedidoItem(string pedidoId, string descricao, int precoUnitario, int qtd)
        {
            Id = Guid.NewGuid();
            PedidoID = pedidoId;
            this.descricao = descricao;
            this.precoUnitario = precoUnitario;
            this.qtd = qtd;
        }

        public decimal CalcularValor()
        {
            return qtd * precoUnitario;
        }

        public override bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(PedidoID)) return false;
            if (string.IsNullOrWhiteSpace(descricao)) return false;
            if (precoUnitario < 0) return false;
            if (qtd <= 0) return false;
            return true;
        }
    }
}
