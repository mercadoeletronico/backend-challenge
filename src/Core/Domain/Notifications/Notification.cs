namespace Domain.Notifications
{
    public class Notification
    {
        public NotificationLevel Level { get; set; }
        public string Description { get; set; }
        public string Label { get; set; }
        public string Message {get; set;}
        public Notification(NotificationLevel level, string description)
        {
            Level = level;
            Description = description;
            this.Message = description;
        }
        public Notification(NotificationLevel level, string message, string label)
        {
            this.Level = level;
            this.Description = message;
            this.Label = label;
            this.Message  = message;
        }
    }
    public enum NotificationLevel
    {
        None = 0,
        Validation = 1,
        Error = 2,
        Forbidden =3
    }
}