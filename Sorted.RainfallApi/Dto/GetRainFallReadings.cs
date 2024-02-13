using System.Text.Json.Serialization;

namespace Sorted.RainfallApi.Dto
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
