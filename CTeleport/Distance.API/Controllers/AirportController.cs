using Distance.Business.Airports.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Distance.API.Controllers
{
    /// <summary>
    /// Airports endpoints
    /// </summary>
    [Route("airports")]
    public class AirportController: ControllerBase
    {
        private readonly IMediator _mediator;

        public AirportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets distance between 2 airports
        /// </summary>
        /// <param name="from">Airport's IATA code from which to find a distance</param>
        /// <param name="to">Airport's IATA code to which to find a distance</param>
        /// <returns>Distance in miles between 2 airports</returns>
        [HttpGet("{from}/distance/{to}")]
        public Task<double> GetDistance(string from, string to)
        {
            return _mediator.Send(new GetAirportsDistanceQuery(from, to));
        }
    }
}
