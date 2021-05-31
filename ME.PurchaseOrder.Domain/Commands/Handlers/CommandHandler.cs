using FluentValidation.Results;
using ME.PurchaseOrder.Domain.Commands.Base;
using ME.PurchaseOrder.Domain.Enums;
using ME.PurchaseOrder.Domain.Extensions;
using ME.PurchaseOrder.Domain.Models.Base;
using ME.PurchaseOrder.Domain.Repositories.Base;
using System;
using System.Threading.Tasks;

namespace ME.PurchaseOrder.Domain.Commands.Handlers
{
    public class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(ErrorCode errorCode, string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem) { ErrorCode = errorCode.GetDescription() });
        }

        protected async Task<ValidationResult> Commit(IUnitOfWork uow, string message)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            if (!await uow.Commit())
                AddError(ErrorCode.CriticalError, message);

            return ValidationResult;
        }

        protected async Task<ValidationResult> Commit(IUnitOfWork uow)
            => await Commit(uow, "There was an error saving data").ConfigureAwait(false);

        protected async Task<ValidationResult> ValidatedWithTargetAndCommit<T, K>(IUnitOfWork unitOfWork, T command, Func<Task<K>> funcTarget, Action<T, K> action)
            where T : Command where K : Entity
        {
            if (!command.IsValid())
                return command.ValidationResult;

            var target = await funcTarget();

            if (target is null)
            {
                AddError(ErrorCode.NumberCodeOrderInvalid, "Não existe nenhum dado registro com esse valor.");
                return ValidationResult;
            }

            action.Invoke(command, target);

            return await Commit(unitOfWork);
        }

        protected async Task<ValidationResult> ValidatedAndCommit<T>(IUnitOfWork unitOfWork, T command, Action<T> action) where T : Command
        {
            if (!command.IsValid())
                return command.ValidationResult;

            action.Invoke(command);

            return await Commit(unitOfWork);
        }
    }
}