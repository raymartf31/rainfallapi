using System.Text.Json.Serialization;

namespace Sorted.RainfallApi.Dto
{
    public class GetRainFallReadingItem
    {
        [JsonPropertyName("dateTime")]
        public string DateTimeString { get; set; }

        [JsonPropertyName("value")]
        public decimal Value { get; set; }
    }
}
