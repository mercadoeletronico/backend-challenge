using System;
using System.ComponentModel;

namespace Core.Helpers
{
    public static class EnumHelper
    {
        public static string ObterDescricaoEnum(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
        /// <summary>
        /// Método que obtém o valor do atributo de descrição para eumeradors
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ObterDescricaoEnum<T>(this T? value) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new Exception("Must be an enum.");

            if (!value.HasValue)
                return string.Empty;

            var fi = value.GetType().GetField(value.Value.ToString());

            var attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        /// <summary>
        /// Método que obtém a Descrição do Enum a partir do valor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ObterDescricaoEnum<T>(dynamic valor)
        {
            return Enum.GetName(typeof(T), Convert.ToInt16(valor));
        }
    }
}
