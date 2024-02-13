﻿using System.Text.Json.Serialization;
using Sorted.RainfallApi.Models;

namespace Sorted.RainfallApi.Responses
{
    /// <summary>
    /// Error response
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Gets or sets the error message
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
        
        /// <summary>
        /// Gets or sets the error details
        /// </summary>
        [JsonPropertyName("detail")]
        public ErrorDetail[] Detail { get; set; }
    }
}
