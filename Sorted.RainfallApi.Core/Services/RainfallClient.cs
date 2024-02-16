using Sorted.RainfallApi.Core.Entities;
using Sorted.RainfallApi.Core.Services.Interfaces;
using Sorted.RainfallApi.Infrastructure.Services.Interfaces;

namespace Sorted.RainfallApi.Core.Services
{
    public class RainfallClient : IRainfallClient
    {
        private readonly IRainfallService _rainfallService;

        public RainfallClient(IRainfallService rainfallService)
        {
            _rainfallService = rainfallService;
        }

        /// <inheritdoc />
        public async Task<List<RainfallReading>> GetReadings(int stationId, int count = 10)
        {
            List<RainfallReading> result = new List<RainfallReading>();
            var response = await _rainfallService.GetReadings(stationId, count);
            if (response != null)
            {
                foreach (var item in response.Items)
                {
                    result.Add(new RainfallReading { AmountMeasured = item.Value, DateMeasured = item.DateTimeString });
                }
            }

            return result;
        }
    }
}
