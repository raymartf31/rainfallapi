using System.Text.Json.Serialization;
using Sorted.RainfallApi.Models;

namespace Sorted.RainfallApi.Responses
{
    /// <summary>
    /// Error response
    /// </summary>
    public class Error
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        
        [JsonPropertyName("detail")]
        public ErrorDetail[] Detail { get; set; }
    }
}
