using System.Collections.Generic;
using System.Linq;

namespace Domain.Notifications
{
    public class NotificationPool
    {
        List<Notification> _notifications;
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public bool HasNotifications => Notifications.Any();

        public NotificationPool()
        {
            this._notifications = new List<Notification>();
        }

        public void Add(NotificationLevel level, string description)
        {
            this._notifications.Add(new Notification(level, description));
        }
        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            this._notifications.AddRange(notifications);
        }

        public void AddNotification(string message, NotificationLevel level, string label = null)
        {
            this._notifications.Add(new Notification(level, message, label));
        }
        
        public void Reset()
        {
            this._notifications.Clear();
            this._notifications = new List<Notification>();
        }
    }
}