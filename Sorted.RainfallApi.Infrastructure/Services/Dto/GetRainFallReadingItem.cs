using System.Text.Json.Serialization;

namespace Sorted.RainfallApi.Infrastructure.Services.Dto
{
    /// <summary>
    /// Rain Fall reading item
    /// </summary>
    public class GetRainFallReadingItem
    {
        /// <summary>
        /// Rain Fall reading date time
        /// </summary>
        [JsonPropertyName("dateTime")]
        public string DateTimeString { get; set; }

        /// <summary>
        /// Rain Fall reading value
        /// </summary>
        [JsonPropertyName("value")]
        public decimal Value { get; set; }
    }
}
