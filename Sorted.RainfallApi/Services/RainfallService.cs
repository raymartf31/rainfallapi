using Sorted.RainfallApi.Dto;
using Sorted.RainfallApi.Extensions;
using Sorted.RainfallApi.Models;
using Sorted.RainfallApi.Services.Interfaces;

namespace Sorted.RainfallApi.Services
{
    public class RainfallService : IRainfallService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly CustomConfigurationManager _customConfigurationManager;

        public RainfallService(
            IHttpClientFactory httpClientFactory,
            CustomConfigurationManager customConfigurationManager)
        {
            _httpClientFactory = httpClientFactory;
            _customConfigurationManager = customConfigurationManager;
        }

        public async Task<List<RainfallReading>> GetReadings(int stationId, int count = 10)
        {
            List<RainfallReading> rainfallReading = new List<RainfallReading>();

            HttpClient client = _httpClientFactory.CreateClient();
            GetRainFallReadings? response = await client.GetAsync<GetRainFallReadings?>(
                $"{_customConfigurationManager.AppSettings.RainfallEndpoint}/id/stations/{stationId}/readings?_sorted&_limit={count}");

            if (response != null)
            {
                foreach (var item in response.Items)
                {
                    rainfallReading.Add(new RainfallReading{ AmountMeasured = item.Value, DateMeasured = item.DateTimeString });
                }
            }

            return rainfallReading;
        }
    }
}
