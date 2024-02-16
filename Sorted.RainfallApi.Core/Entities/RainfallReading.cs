using System.Text.Json.Serialization;

namespace Sorted.RainfallApi.Core.Entities
{
    /// <summary>
    /// Rainfall reading
    /// </summary>
    public class RainfallReading
    {
        /// <summary>
        /// Gets or sets the date measured
        /// </summary>
        [JsonPropertyName("dateMeasured")]
        public string DateMeasured { get; set; }

        /// <summary>
        /// Gets or sets the amount measured
        /// </summary>
        [JsonPropertyName("amountMeasured")]
        public decimal AmountMeasured { get; set; }
    }
}
