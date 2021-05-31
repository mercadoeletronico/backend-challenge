using FluentValidation;
using ME.PurchaseOrder.Domain.Enums;
using ME.PurchaseOrder.Domain.Extensions;

namespace ME.PurchaseOrder.Domain.Commands.Validators
{
    public class UpdateOrderStatusCommandValidator : AbstractValidator<UpdateOrderStatusCommand>
    {
        public UpdateOrderStatusCommandValidator()
        {
            RuleFor(x => x.NumberOrder)
                .NotEmpty()
                .NotNull()
                .Must(x => x.Length == x.OnlyNumbers().Length)
                .WithErrorCode(ErrorCode.NumberCodeOrderInvalid.GetDescription())
                .WithMessage("O campo \"pedido\" está invalido.");

            RuleFor(x => x.Status)
                .NotNull()
                .IsInEnum()
                .WithErrorCode(ErrorCode.InvalidRequest.GetDescription())
                .WithMessage("O campo \"status\" é obrigatório.");

            RuleFor(x => x.ApprovedItems)
                .NotNull()
                .GreaterThan(0)
                .When(x => x.Status.Equals(OrderStatus.Approved))
                .WithErrorCode(ErrorCode.InvalidRequest.GetDescription())
                .WithMessage("O campo \"itensAprovados\" tem que ser maior que 0.");

            RuleFor(x => x.ApprovedValue)
                .NotNull()
                .GreaterThan(0)
                .When(x => x.Status.Equals(OrderStatus.Approved))
                .WithErrorCode(ErrorCode.InvalidRequest.GetDescription())
                .WithMessage("O campo \"valorAprovado\" tem que ser maior que 0.");
        }
    }
}