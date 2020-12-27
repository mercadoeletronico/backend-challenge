namespace Core.Models.Filters
{
    public class BaseRequestFilter
    {
        public int Take { get; set; } = 100;
        public int Offset { get; set; } = 0;
    }
}
