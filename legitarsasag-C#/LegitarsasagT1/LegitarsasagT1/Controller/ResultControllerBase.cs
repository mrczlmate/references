using LegitarsasagT1.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LegitarsasagT1.Controller
{
    [Route("result")]
    
    public abstract class ResultControllerBase : ControllerBase
    {
        [HttpGet]
        public abstract List<Flight> AllFlight();
        
        [HttpGet("{id}")]
        public abstract List<Flight> AllFlightByAirline(int id);
        
        
    }
}

