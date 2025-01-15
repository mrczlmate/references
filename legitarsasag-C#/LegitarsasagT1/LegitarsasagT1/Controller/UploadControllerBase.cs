using System.Collections.Generic;
using LegitarsasagT1.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LegitarsasagT1.Controller
{
    [Route("upload")]
    public abstract class UploadControllerBase : ControllerBase
    {
        [HttpPost("city")]
        public abstract List<City> ReadCity([FromForm(Name = "city")] IFormFile file);
        [HttpPost("flight")]
        public abstract List<Flight> ReadFlight([FromForm(Name = "flight")] IFormFile file);
    }
}