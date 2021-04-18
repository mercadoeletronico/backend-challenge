using System.Collections.Generic;

namespace MercadoEletronico.Challenge.Util
{
    public class Result
    {
        public ResultStatus Status { get; }

        public List<string> Notifications { get; }

        protected Result()
        {
            Notifications = new List<string>();
        }

        public Result(ResultStatus status) : this()
        {
            Status = status;
        }

        public Result(ResultStatus status, string message) : this(status)
        {
            Notifications.Add(message);
        }

        public Result(ResultStatus status, IEnumerable<string> messages) : this(status)
        {
            if (!(messages is null))
            {
                Notifications = messages.ToList();
            }
        }

        public void AddNotification(string notification)
        {
            Notifications.Add(notification);
        }

        public void AddNotification(IEnumerable<string> notifications)
        {
            Notifications.AddRange(notifications);
        }
    }

    public class Result<T> : Result
    {
        public T Content { get; }

        public Result(ResultStatus status) : base(status)
        {
        }

        public Result(ResultStatus status, string message) : base(status, message)
        {
        }

        public Result(ResultStatus status, IEnumerable<string> messages) : base(status, messages)
        {
        }

        public Result(ResultStatus status, T content) : this(status)
        {
            Content = content;
        }

        public Result(ResultStatus status, string message, T content) : base(status, message)
        {
            Content = content;
        }

        public Result(ResultStatus status, IEnumerable<string> messages, T content) : base(status, messages)
        {
            Content = content;
        }
    }
}
