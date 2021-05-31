using ME.PurchaseOrder.Domain.Commands.Base;
using ME.PurchaseOrder.Domain.Commands.Validators;

namespace ME.PurchaseOrder.Domain.Commands
{
    public class DeleteOrderCommand : Command
    {
        public DeleteOrderCommand(string numberOrder)
        {
            NumberOrder = numberOrder;
        }

        public string NumberOrder { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new DeleteOrderCommandValidator().Validate(this);
            return base.IsValid();
        }
    }
}