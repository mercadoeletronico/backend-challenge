using FluentValidation.Results;
using PedidosME.Domain.Entities.Core;
using PedidosME.Domain.Entities.PedidoAggregate.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosME.Domain.PedidoAggregate.Entities
{
    public class Pedido : Entity
    {
        private ValidationResult validation = new ValidationResult();
        PedidoValidator validator = new PedidoValidator();
        public Pedido()
        {

        }
        public Pedido(string codigo, IEnumerable<ItemPedido> itens)
        {
            Codigo = codigo;
            Itens = itens;
            validation = validator.Validate(this);
        }



        public string Codigo { get; private set; }
        public IEnumerable<ItemPedido> Itens { get; private set; }


        public override ValidationResult ValidationResult => validation;
        public override bool IsValid =>  validation.Errors?.Count == 0;
            


        public static Pedido Criar(string codigo)
        {
            return new Pedido() { Codigo = codigo };
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is Pedido pedido)) return false;
            if (GetType() != pedido.GetType()) return false;
            return Codigo == pedido.Codigo;
        }

        public override int GetHashCode() => Codigo.GetHashCode();
        
    }
}
