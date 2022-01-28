using System.Text.Json.Serialization;

namespace ORDER.Domain.Dto
{
    public class StatusErrorDto
    {
        public StatusErrorDto(string status)
        {
            Status = status;
        }
        
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}