using Sorted.RainfallApi.Infrastructure.Services.Dto;

namespace Sorted.RainfallApi.Infrastructure.Services.Interfaces
{
    /// <summary>
    /// Rainfall Api Definitions
    /// </summary>
    public interface IRainfallService
    {
        /// <summary>
        /// Gets the rain fall readings by station id
        /// </summary>
        /// <param name="stationId">Station Id</param>
        /// <param name="count">Number of readings to get</param>
        /// <returns>Readings</returns>
        Task<GetRainFallReadings?> GetReadings(int stationId, int count = 10);
    }
}
