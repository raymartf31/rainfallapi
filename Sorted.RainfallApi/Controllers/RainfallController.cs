using Microsoft.AspNetCore.Mvc;
using Sorted.RainfallApi.Extensions;
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
            List<RainfallReading> readings;

            try
            {
                if (!stationId.IsNumber())
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        new ErrorResponse
                        {
                            Message = "Invalid request",
                            Detail = new ErrorDetail[]
                            {
                                new ErrorDetail{ Message = "Invalid Station Id", PropertyName = nameof(stationId) }
                            }
                        });
                }

                readings = await _rainfallService.GetReadings(Convert.ToInt32(stationId), count);

                if (!readings.Any())
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        new ErrorResponse
                        {
                            Message = "No readings found for the specified stationId"
                        });
                }
            }
            catch (Exception ex)
            {
                // Log ex
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponse
                    {
                        Message = "Internal server error",
                        Detail = new ErrorDetail[]
                        {
                            new ErrorDetail{ Message = "Please contact an administrator" }
                        }
                    });
            }

            return Ok(new RainfallReadingResponse { Readings = readings });
        }
    }
}
