using System.Collections.Generic;

namespace Domain.Notifications
{
    public interface INotifiable
    {
        bool HasNotifications {get;}
        IReadOnlyCollection<Notification> Notifications {get;}
    }
}