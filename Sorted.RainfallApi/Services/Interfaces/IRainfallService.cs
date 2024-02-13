using Sorted.RainfallApi.Models;

namespace Sorted.RainfallApi.Services.Interfaces
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
        /// <returns>List of readings</returns>
        Task<List<RainfallReading>> GetReadings(int stationId, int count = 10);
    }
}
