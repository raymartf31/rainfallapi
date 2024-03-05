namespace Sorted.RainfallApi.Models
{
    public class RainfallResultResponse
    {
        public RainfallReadingResponse RainfallReading { get; set; } = new RainfallReadingResponse();
        public ErrorResponse Error { get; set; } = new ErrorResponse();
    }
}
