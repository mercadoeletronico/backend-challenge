using FluentValidation;

namespace MercadoEletronico.Teste.Domain.Entities.Validations
{
    public class ItemValidation : AbstractValidator<Item>
    {
        public ItemValidation()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(1, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}