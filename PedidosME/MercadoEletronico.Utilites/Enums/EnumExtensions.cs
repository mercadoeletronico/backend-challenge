using System;
using System.Collections.Generic;
using System.Text;

namespace MercadoEletronico.Utilities.Enums
{
    public static class EnumExtensions
    {
        public static string GetText<T>(this Enum myenum  )
        {
            return Enum.GetName(myenum.GetType(), myenum);
        }
    }
}
