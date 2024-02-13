using System.Text.Json.Serialization;

namespace Sorted.RainfallApi.Models
{
    /// <summary>
    /// Details of invalid request property
    /// </summary>
    public class ErrorDetail
    {
        [JsonPropertyName("propertyName")]
        public string PropertyName { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
