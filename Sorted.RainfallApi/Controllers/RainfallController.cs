using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;

using Sorted.RainfallApi.Core.Entities;
using Sorted.RainfallApi.Core.Services.Interfaces;
using Sorted.RainfallApi.Models;

namespace Sorted.RainfallApi.Controllers
{
    [Route("rainfall")]
    [ApiController]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallClient _rainfallClient;

        public RainfallController(IRainfallClient rainfallClient)
        {
            _rainfallClient = rainfallClient;
        }

        /// <summary>
        /// Get rainfall readings by station Id
        /// </summary>
        /// <param name="stationId">The id of the reading station</param>
        /// <param name="count">The number of readings to return</param>
        /// <returns code="200">Successful</returns>
        [HttpGet("id/{stationId}/readings")]
        [ProducesResponseType(typeof(RainfallResultResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RainfallResultResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RainfallResultResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RainfallResultResponse>> GetRainfall([Range(0, int.MaxValue, ErrorMessage = "Invalid Station Id")][FromRoute]string stationId, int count = 10)
        {
            List<RainfallReading> readings;

            try
            {
                readings = await _rainfallClient.GetReadings(Convert.ToInt32(stationId), count);

                if (!readings.Any())
                {
                    return NotFound(new RainfallResultResponse
                    {
                        Error = new ErrorResponse
                        {
                            Message = "No readings found for the specified stationId"
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                // Log ex
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new RainfallResultResponse
                    {
                        Error = new ErrorResponse
                        {
                            Message = "Internal server error",
                            Detail = new ErrorDetail[]
                            {
                                new ErrorDetail{ Message = "Please contact an administrator" }
                            }
                        }
                    });
            }

            return Ok(new RainfallResultResponse
            {
                RainfallReading = new RainfallReadingResponse { Readings = readings }
            });
        }
    }
}
