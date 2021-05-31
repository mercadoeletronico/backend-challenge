using System.Linq;

namespace ME.PurchaseOrder.Domain.Extensions
{
    public static class StringExtension
    {
        public static string OnlyNumbers(this string source)
            => new string(source.Where(char.IsDigit).ToArray());
    }
}