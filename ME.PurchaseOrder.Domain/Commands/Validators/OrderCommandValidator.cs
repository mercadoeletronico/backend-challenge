using FluentValidation;
using ME.PurchaseOrder.Domain.Commands.OrderBase;
using ME.PurchaseOrder.Domain.Enums;
using ME.PurchaseOrder.Domain.Extensions;

namespace ME.PurchaseOrder.Domain.Commands.Validators
{
    public class OrderCommandValidator : AbstractValidator<OrderCommand>
    {
        public OrderCommandValidator()
        {
            RuleFor(x => x.NumberOrder)
                .NotEmpty()
                .NotNull()
                .Must(x => x.Length == x.OnlyNumbers().Length)
                .WithErrorCode(ErrorCode.NumberCodeOrderInvalid.GetDescription())
                .WithMessage("Pedido está invalido.");

            RuleFor(x => x.Items)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode.InvalidRequest.GetDescription())
                .WithMessage("è necessario um item no pedido.");

            RuleForEach(x => x.Items)
                .SetValidator(new OrderItemCommandValidator());
        }
    }
}