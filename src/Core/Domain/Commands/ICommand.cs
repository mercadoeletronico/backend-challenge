using Domain.Notifications;

namespace Domain.Commands
{
    public interface ICommand : INotifiable
    {
        void Validate();
         
    }
}