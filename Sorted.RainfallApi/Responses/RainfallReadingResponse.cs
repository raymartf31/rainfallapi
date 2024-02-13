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
        public List<RainfallReading> Readings { get; set; }
    }
}
