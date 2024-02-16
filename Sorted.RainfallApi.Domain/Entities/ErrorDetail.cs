using System.Text.Json.Serialization;

namespace Sorted.RainfallApi.Core.Entities
{
    /// <summary>
    /// Details of invalid request property
    /// </summary>
    public class ErrorDetail
    {
        /// <summary>
        /// Gets or sets the property name
        /// </summary>
        [JsonPropertyName("propertyName")]
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the message
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
