using Sorted.RainfallApi.Models;

namespace Sorted.RainfallApi.Services.Interfaces
{
    public interface IRainfallService
    {
        Task<List<RainfallReading>> GetReadings(int stationId, int count = 10);
    }
}
