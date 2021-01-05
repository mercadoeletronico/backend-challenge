using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.Domain.Models
{
	public class Notification
	{

		public string Message { get; }

		public Notification(string message)
		{

			Message = message;
		}
	}
}
