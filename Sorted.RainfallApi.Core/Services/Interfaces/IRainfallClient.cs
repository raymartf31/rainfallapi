using Sorted.RainfallApi.Core.Entities;

namespace Sorted.RainfallApi.Core.Services.Interfaces
{
    public interface IRainfallClient
    {
        Task<List<RainfallReading>> GetReadings(int stationId, int count = 10);
    }
}
