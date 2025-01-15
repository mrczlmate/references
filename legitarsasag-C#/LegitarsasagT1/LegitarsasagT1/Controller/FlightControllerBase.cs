using LegitarsasagT1.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LegitarsasagT1.Controller
{
    [Route("flight")]
    public abstract class FlightControllerBase : ControllerBase
    {
        [HttpGet]
        public abstract List<Flight> FindAll();

        [HttpGet("{id}")]
        public abstract Flight FindById(int id);

        [HttpPost]
        public abstract Flight Save([FromBody] Flight flight);

        [HttpPut("{id}")]
        public abstract Flight Update(int id, [FromBody] Flight flight);

        [HttpDelete("{id}")]
        public abstract void Delete(int id);

        [HttpGet("way")]
        public abstract List<Flight> Way([FromQuery(Name = "fromCityId")] int fromCityId,
            [FromQuery(Name = "toCityId")] int toCityId);
        
    }
}