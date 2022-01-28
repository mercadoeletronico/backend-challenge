using System.Text.Json.Serialization;

namespace ORDER.API.ViewModels
{
    public class ErrorModel
    {
        [JsonIgnore] public int Code { get; set; }

        [JsonPropertyName("status")] public string Message { get; set; }

        [JsonIgnore] public string? StackTrace { get; set; }
    }
}