using DomainValidation.Validation;
using Pedido.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pedido.Domain.Notifications
{
    public class NotificationContext
    {
		private readonly List<Notification> _notifications;
		public IReadOnlyCollection<Notification> Notifications => _notifications;
		public bool HasNotifications => _notifications.Any();

		public NotificationContext()
		{
			_notifications = new List<Notification>();
		}

		public void AddNotification(string message)
		{
			_notifications.Add(new Notification(message));
		}

		public void AddNotification(Notification notification)
		{
			_notifications.Add(notification);
		}

		public void AddNotifications(IReadOnlyCollection<Notification> notifications)
		{
			_notifications.AddRange(notifications);
		}

		public void AddNotifications(IList<Notification> notifications)
		{
			_notifications.AddRange(notifications);
		}

		public void AddNotifications(ICollection<Notification> notifications)
		{
			_notifications.AddRange(notifications);
		}

		public void AddNotifications(ValidationResult validationResult)
		{

			foreach (var error in validationResult.Erros)
			{
				AddNotification(error.Message);
			}
		}
	}
}
