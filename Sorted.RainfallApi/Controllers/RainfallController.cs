using Microsoft.AspNetCore.Mvc;
using Sorted.RainfallApi.Models;
using Sorted.RainfallApi.Responses;

namespace Sorted.RainfallApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RainfallController : ControllerBase
    {
        /// <summary>
        /// Get rainfall readings by station Id
        /// </summary>
        /// <param name="stationId">The id of the reading station</param>
        /// <param name="count">The number of readings to return</param>
        /// <returns></returns>
        [HttpGet("id/{stationId}/readings")]
        [ProducesResponseType(typeof(RainfallReadingResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetRainfall(string stationId, int count = 10)
        {
            RainfallReading[] someSampleReading =
            {
                new RainfallReading
                {
                    AmountMeasured = 1.0m,
                    DateMeasured = DateTime.Now.ToString("d")
                }
            }; 

            return Ok(new RainfallReadingResponse{ Readings = someSampleReading });
        }
    }
}
