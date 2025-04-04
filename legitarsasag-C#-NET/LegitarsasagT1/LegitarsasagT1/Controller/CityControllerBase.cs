using LegitarsasagT1.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LegitarsasagT1.Controller
{
    [Route("city")]
    public abstract class CityControllerBase : ControllerBase
    {
        [HttpGet]
        public abstract List<City> FindAll();

        [HttpGet("{id}")]
        public abstract City FindById(int id);

        [HttpPost]
        public abstract City Save([FromBody] City city);

        [HttpPut("{id}")]
        public abstract City Update(int id, [FromBody] City city);

        [HttpDelete("{id}")]
        public abstract void Delete(int id);
    }
}
