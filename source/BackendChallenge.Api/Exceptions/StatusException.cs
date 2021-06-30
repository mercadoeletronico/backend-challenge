using System.Collections.Generic;

namespace BackendChallenge.Api.Exceptions
{
    public class StatusException : System.Exception
    {
        public List<string> Status { get; private set; }

        public StatusException(string status)
        {
            Status = new List<string>();
            Status.Add(status);
        }

        public StatusException(List<string> status)
        {
            Status = status;
        }

        public List<string> GetStatus()
        {
            return Status;
        }
    }
}