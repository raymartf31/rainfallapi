using System.Text.Json.Serialization;

namespace Sorted.RainfallApi.Models
{
    /// <summary>
    /// Rainfall reading
    /// </summary>
    public class RainfallReading
    {
        [JsonPropertyName("dateMeasured")]
        public string DateMeasured { get; set; }

        [JsonPropertyName("amountMeasured")]
        public decimal AmountMeasured { get; set; }
    }
}
