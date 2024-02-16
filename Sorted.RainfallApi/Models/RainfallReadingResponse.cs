using System.Text.Json.Serialization;
using Sorted.RainfallApi.Core.Entities;

namespace Sorted.RainfallApi.Models
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
