using Microsoft.AspNetCore.Mvc;

using Sorted.RainfallApi.Models;
using Sorted.RainfallApi.Responses;
using Sorted.RainfallApi.Services.Interfaces;

namespace Sorted.RainfallApi.Controllers
{
    [Route("rainfall")]
    [ApiController]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallService _rainfallService;

        public RainfallController(IRainfallService rainfallService)
        {
            _rainfallService = rainfallService;
        }

        /// <summary>
        /// Get rainfall readings by station Id
        /// </summary>
        /// <param name="stationId">The id of the reading station</param>
        /// <param name="count">The number of readings to return</param>
        /// <returns></returns>
        [HttpGet("id/{stationId}/readings")]
        [ProducesResponseType(typeof(RainfallReadingResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRainfall(string stationId, int count = 10)
        {
            List<RainfallReading> readings = await _rainfallService.GetReadings(Convert.ToInt32(stationId), count);

            return Ok(new RainfallReadingResponse{ Readings = readings });
        }
    }
}
