using Sorted.RainfallApi.Core.Entities;
using Sorted.RainfallApi.Core.Interfaces;

namespace Sorted.RainfallApi
{
    /// <summary>
    /// Custom configuration manager
    /// </summary>
    public class CustomConfigurationManager : ICustomConfigManager
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
