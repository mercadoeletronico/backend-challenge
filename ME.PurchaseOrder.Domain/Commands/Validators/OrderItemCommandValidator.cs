using FluentValidation;
using ME.PurchaseOrder.Domain.Commands.OrderBase;
using ME.PurchaseOrder.Domain.Enums;
using ME.PurchaseOrder.Domain.Extensions;

namespace ME.PurchaseOrder.Domain.Commands.Validators
{
    public class OrderItemCommandValidator : AbstractValidator<OrderItemCommand>
    {
        public OrderItemCommandValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithErrorCode(ErrorCode.InvalidRequest.GetDescription())
                .WithMessage("O campo \"Descrição\" é obrigatório.");

            RuleFor(x => x.Quantity)
                .NotNull()
                .GreaterThan(0)
                .WithErrorCode(ErrorCode.InvalidRequest.GetDescription())
                .WithMessage("O campo \"Qtd\" tem que ser maior que zero.");

            RuleFor(x => x.UnitPrice)
                .NotNull()
                .GreaterThan(0)
                .WithErrorCode(ErrorCode.InvalidRequest.GetDescription())
                .WithMessage("O campo \"precoUnitario\" tem que ser maior que zero.");
        }
    }
}