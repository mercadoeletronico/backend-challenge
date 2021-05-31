using System;
using System.ComponentModel;

namespace ME.PurchaseOrder.Domain.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum source)
        {
            var attributes = (DescriptionAttribute[])source
               .GetType()
               .GetField(source.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : source.ToString();
        }
    }
}