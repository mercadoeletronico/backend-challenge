using System;
using System.ComponentModel;
using System.Linq;

namespace MercadoEletronico.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            var memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (_Attribs != null && _Attribs.Any())
                {
                    return ((DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }

            return GenericEnum.ToString();
        }
    }
}