using Core.Models.Requests.Pedido;
using FluentValidation;
using FluentValidation.Results;

namespace Core.Models.Validations
{
    public class SavePedidoValidator: AbstractValidator<SavePedidoRequest>
    {
        public SavePedidoValidator()
        {
            RuleFor(x => x.Codigo).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório!");
            RuleFor(x => x.Itens).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório!");
        }
    }
}
