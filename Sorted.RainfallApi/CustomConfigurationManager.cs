using Sorted.RainfallApi.Models;

namespace Sorted.RainfallApi
{
    /// <summary>
    /// Custom configuration manager
    /// </summary>
    public class CustomConfigurationManager
    {
        public CustomConfigurationManager(AppSettings appSettings)
        {
            AppSettings = appSettings;
        }

        /// <summary>
        /// Gets or sets the application settings
        /// </summary>
        public AppSettings AppSettings { get; }
    }
}
