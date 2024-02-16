using System.Text.Json.Serialization;

namespace Sorted.RainfallApi.Infrastructure.Services.Dto
{
    /// <summary>
    /// Rain fall readings
    /// </summary>
    public class GetRainFallReadings
    {
        /// <summary>
        /// Rain Fall reading items
        /// </summary>
        [JsonPropertyName("items")]
        public GetRainFallReadingItem[] Items { get; set; }
    }
}
