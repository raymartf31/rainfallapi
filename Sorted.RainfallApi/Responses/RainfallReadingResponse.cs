using System.Text.Json.Serialization;
using Sorted.RainfallApi.Models;

namespace Sorted.RainfallApi.Responses
{
    /// <summary>
    /// Rainfall reading response
    /// </summary>
    public class RainfallReadingResponse
    {
        [JsonPropertyName("readings")]
        public RainfallReading[] Readings { get; set; }
    }
}
