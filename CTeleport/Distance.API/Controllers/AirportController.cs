using Microsoft.AspNetCore.Mvc;

namespace Distance.API.Controllers
{
    /// <summary>
    /// Airports endpoints
    /// </summary>
    [Route("airports")]
    public class AirportController: ControllerBase
    {
        /// <summary>
        /// Gets distance between 2 airports
        /// </summary>
        /// <param name="from">Airport's IATA code from which to find a distance</param>
        /// <param name="to">Airport's IATA code to which to find a distance</param>
        /// <returns>Distance in miles between 2 airports</returns>
        [HttpGet("{from}/distance/{to}")]
        public Task<int> GetDistance(string from, string to)
        {
            return Task.FromResult(0);
        }
    }
}
