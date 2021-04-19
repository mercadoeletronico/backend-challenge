using System;
using System.Linq;

namespace MercadoEletronico.Challenge.Util.Extensions
{
    public static class ObjectExtensions
    {
        public static bool In<T>(this T @object, params T[] objects) where T : IEquatable<T>
        {
            return objects.Any(obj => obj.Equals(@object));
        }

        public static bool NotIn<T>(this T @object, params T[] objects) where T : IEquatable<T>
            => @object.In(objects) is false;
    }
}
