using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Notifications;
using Domain.Commands;
namespace Domain.CommandHandler{
    public abstract class CommandHandler<TCommand, TResult> : INotifiable where TCommand : ICommand
    {
        protected NotificationPool _notificationPool;
        public virtual IReadOnlyCollection<Notification> Notifications => this._notificationPool.Notifications;
        public virtual bool HasNotifications => this._notificationPool.HasNotifications;
        protected CommandHandler()
        {
            this._notificationPool = new NotificationPool();
        }

        public virtual async Task<TResult> Handle(TCommand command)
        {
            if(command == null)
            {
                this._notificationPool.AddNotification("Não foi possivel interpretar as informações passadas", NotificationLevel.Validation);
                return default(TResult);
            }
            command.Validate();
            if(!command.HasNotifications)
            {
                return await this.RunCommand(command);
            }
            else
            {
                this._notificationPool.AddNotifications(command.Notifications);
                return default(TResult);
            }
        }
        protected abstract Task<TResult> RunCommand(TCommand command);
    }
}
