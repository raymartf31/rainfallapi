using System.Text.Json.Serialization;
using Sorted.RainfallApi.Models;

namespace Sorted.RainfallApi.Responses
{
    /// <summary>
    /// Rainfall reading response
    /// </summary>
    public class RainfallReadingResponse
    {
        /// <summary>
        /// Gets or sets the readings
        /// </summary>
        [JsonPropertyName("readings")]
        public List<RainfallReading> Readings { get; set; }
    }
}
