using ME.PurchaseOrder.Domain.Commands.OrderBase;
using ME.PurchaseOrder.Domain.Commands.Validators;
using System.Collections.Generic;

namespace ME.PurchaseOrder.Domain.Commands
{
    public class UpdateOrderCommand : OrderCommand
    {
        public UpdateOrderCommand()
        {
        }

        public UpdateOrderCommand(string pedido, ICollection<OrderItemCommand> orderItens)
        {
            this.NumberOrder = pedido;
            this.Items = orderItens;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateOrderCommandValitador().Validate(this);
            return base.IsValid();
        }
    }
}