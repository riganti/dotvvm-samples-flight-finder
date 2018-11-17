using FlightFinder.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlightFinder.Api.Controllers
{
    [Route("api/[controller]")]
    public class AirportsController : Controller
    {
        [HttpGet]
        public IEnumerable<Airport> Airports()
        {
            return SampleData.Airports;
        }
    }
}
