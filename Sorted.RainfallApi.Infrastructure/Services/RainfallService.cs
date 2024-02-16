using Sorted.RainfallApi.Extensions;
using Sorted.RainfallApi.Infrastructure.Services.Dto;
using Sorted.RainfallApi.Infrastructure.Services.Interfaces;

namespace Sorted.RainfallApi.Infrastructure.Services
{
    /// <summary>
    /// Consumes Rainfall Api
    /// </summary>
    public class RainfallService : IRainfallService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUri;

        public RainfallService(
            IHttpClientFactory httpClientFactory,
            string baseUri)
        {
            _httpClientFactory = httpClientFactory;
            _baseUri = baseUri;
        }

        /// <inheritdoc />
        public async Task<GetRainFallReadings?> GetReadings(int stationId, int count = 10)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            GetRainFallReadings? response = await client.GetAsync<GetRainFallReadings?>(
                $"{_baseUri}/id/stations/{stationId}/readings?_sorted&_limit={count}");

            return response;
        }
    }
}
