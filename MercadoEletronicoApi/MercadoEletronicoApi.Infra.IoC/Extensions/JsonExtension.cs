using System.Text.Json;

namespace MercadoEletronicoApi.Extensions
{
    public static class JsonExtension
    {
        private static JsonSerializerOptions _serializerOptions;

        private static JsonSerializerOptions SerializerOptions
        {
            get
            {
                if (_serializerOptions == null)
                    InitializationEventAttributes();
                return _serializerOptions;
            }
        }

        private static void InitializationEventAttributes()
        {
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreReadOnlyFields = true,
                IgnoreReadOnlyProperties = true
            };
        }

        public static string ToJson(this object value) => JsonSerializer.Serialize(value);

        public static T FromJson<T>(this string value) where T : class =>
            JsonSerializer.Deserialize<T>(value, SerializerOptions);
    }

}