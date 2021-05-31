using ME.PurchaseOrder.Domain.Commands.Base;
using ME.PurchaseOrder.Domain.Commands.Validators;
using ME.PurchaseOrder.Domain.Enums;

namespace ME.PurchaseOrder.Domain.Commands
{
    public class UpdateOrderStatusCommand : Command
    {
        public OrderStatus Status { get; set; }
        public int ApprovedItems { get; set; }
        public decimal ApprovedValue { get; set; }
        public string NumberOrder { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new UpdateOrderStatusCommandValidator().Validate(this);
            return base.IsValid();
        }
    }
}