using LegitarsasagT1.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LegitarsasagT1.Controller
{
    [Route("airline")]
    public abstract class AirlineControllerBase : ControllerBase
    {
        [HttpGet]
        public abstract List<Airline> FindAll();

        [HttpGet("{id}")]
        public abstract Airline FindById(int id);

        [HttpPost]
        public abstract Airline Save([FromBody] Airline airline);

        [HttpPut("{id}")]
        public abstract Airline Update(int id, [FromBody] Airline airline);

        [HttpDelete("{id}")]
        public abstract void Delete(int id);

        [HttpGet("{airlineId}/flight")]
        public abstract List<Flight> GetFlightsByAirline(int airlineId);
    }
}
