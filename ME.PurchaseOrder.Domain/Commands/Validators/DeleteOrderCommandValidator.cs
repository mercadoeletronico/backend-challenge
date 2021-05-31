using FluentValidation;
using ME.PurchaseOrder.Domain.Enums;
using ME.PurchaseOrder.Domain.Extensions;

namespace ME.PurchaseOrder.Domain.Commands.Validators
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(x => x.NumberOrder)
                .NotEmpty()
                .NotNull()
                .Must(x => x.Length == x.OnlyNumbers().Length)
                .WithErrorCode(ErrorCode.NumberCodeOrderInvalid.GetDescription())
                .WithMessage("Pedido está invalido.");
        }
    }
}