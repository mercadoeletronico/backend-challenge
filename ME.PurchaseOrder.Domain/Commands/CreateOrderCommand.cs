using ME.PurchaseOrder.Domain.Commands.OrderBase;
using ME.PurchaseOrder.Domain.Commands.Validators;
using System.Collections.Generic;

namespace ME.PurchaseOrder.Domain.Commands
{
    public class CreateOrderCommand : OrderCommand
    {
        public CreateOrderCommand() : base()
        {
        }

        public CreateOrderCommand(string pedido, ICollection<OrderItemCommand> orderItens)
        {
            this.NumberOrder = pedido;
            this.Items = orderItens;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateOrderCommandValitador().Validate(this);
            return base.IsValid();
        }
    }
}