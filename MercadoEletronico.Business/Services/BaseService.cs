using FluentValidation;
using FluentValidation.Results;

namespace MercadoEletronico.Business.Services
{
    public abstract class BaseService
    {
        private readonly Interfaces.INotificador _Notificador;

        public BaseService(Interfaces.INotificador notificador)
        {
            _Notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _Notificador.Adicionar(new Notificacoes.Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : class
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}