using System.Linq;

namespace BackendChallenge.Application.Extensions
{
    public static class OrderExtensions
    {
        public static bool IsNumeric(this string orderNumber)
            => orderNumber.All(c => char.IsNumber(c));

        public static int AsNumberOrZero(this string orderNumber)
            => int.Parse(orderNumber.OnlyNumbers());

        public static string OnlyNumbers(this string orderNumber)
            => new string(orderNumber.Where(c => char.IsNumber(c)).DefaultIfEmpty('0').ToArray());
    }
}
