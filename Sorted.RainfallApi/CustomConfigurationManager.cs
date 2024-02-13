using Sorted.RainfallApi.Models;

namespace Sorted.RainfallApi
{
    public class CustomConfigurationManager
    {
        public CustomConfigurationManager(AppSettings appSettings)
        {
            AppSettings = appSettings;
        }

        public AppSettings AppSettings { get; }
    }
}
