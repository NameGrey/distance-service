using Microsoft.AspNetCore.Mvc;

namespace Distance.API.Controllers
{
    [Route("airports")]
    public class AirportController: ControllerBase
    {

        [HttpGet("{from}/distance/{to}")]
        public Task<int> GetDistance(string from, string to)
        {
            return Task.FromResult(0);
        }
    }
}
