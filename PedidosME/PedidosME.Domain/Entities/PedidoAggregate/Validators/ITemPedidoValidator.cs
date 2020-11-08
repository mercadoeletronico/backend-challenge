using FluentValidation;
using PedidosME.Domain.PedidoAggregate.Entities;

namespace PedidosME.Domain.Entities.PedidoAggregate.Validators
{
    public class ITemPedidoValidator : AbstractValidator<ItemPedido>
    {
        public ITemPedidoValidator()
        {
            RuleFor(x => x.Descricao)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(10);

            RuleFor(x => x.Quantidade)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.PrecoUnitario)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
