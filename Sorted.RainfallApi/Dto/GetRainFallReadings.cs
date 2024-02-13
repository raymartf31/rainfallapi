using System.Text.Json.Serialization;

namespace Sorted.RainfallApi.Dto
{
    public class GetRainFallReadings
    {
        [JsonPropertyName("items")]
        public GetRainFallReadingItem[] Items { get; set; }
    }
}
