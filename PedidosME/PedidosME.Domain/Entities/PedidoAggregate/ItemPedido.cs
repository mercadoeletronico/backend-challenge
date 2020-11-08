using FluentValidation.Results;
using PedidosME.Domain.Entities.Core;
using PedidosME.Domain.Entities.PedidoAggregate.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosME.Domain.PedidoAggregate.Entities
{
    public class ItemPedido : Entity
    {
        private ValidationResult validation;
        public ItemPedido()
        {

        }
        public ItemPedido(string descricao, float precoUnitario, float quantidade) 
        {
            Descricao = descricao;
            PrecoUnitario = precoUnitario;
            Quantidade = quantidade;
            var validator = new ITemPedidoValidator();
            validation = validator.Validate(this);
        }

        public string Descricao { get; private set; }
        public float PrecoUnitario { get; private set; }
        public float Quantidade { get; private set; }

        public Pedido Pedido { get; private set; }
        public string CodigoPedido { get; private set; }

        public static ItemPedido Criar(string codigoPedido, string descricaoItem, float valor, float quantidade)
        {
            return new ItemPedido() { CodigoPedido = codigoPedido, Descricao = descricaoItem, PrecoUnitario = valor, Quantidade = quantidade };
        }

        public override bool IsValid => validation.Errors.Count == 0;


        public override ValidationResult ValidationResult => validation;

        
    }
}
