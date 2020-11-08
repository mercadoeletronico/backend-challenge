using FluentValidation;
using PedidosME.Domain.PedidoAggregate.Entities;
using System.Linq;

namespace PedidosME.Domain.Entities.PedidoAggregate.Validators
{
    public class PedidoValidator : AbstractValidator<Pedido>
    {
        public PedidoValidator()
        {
            RuleFor(x => x.Codigo)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Itens)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .Must(it => it.Any())
                .WithMessage("O pedido deve conter pelo menos um item de pedido.");

            
        }
    }
}
