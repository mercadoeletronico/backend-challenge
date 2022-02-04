using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace MercadoEletronico.Domain.Extensions
{
    public static class ObjectExtensions
    {
        public static bool In<T>(this T @object, params T[] objects) where T : IEquatable<T>
        {
            return objects.Any(obj => obj.Equals(@object));
        }

        public static bool NotIn<T>(this T @object, params T[] objects) where T : IEquatable<T>
            => @object.In(objects) is false;

        public static StringContent ToStringContent(this object @object)
        {
            var json = JsonConvert.SerializeObject(@object);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}