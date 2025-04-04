using DAL6QM_HFT_2023241.Endpoint.Services;
using DAL6QM_HFT_2023241.Logic;
using DAL6QM_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DAL6QM_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryLogic logic;
        IHubContext<SignalRHub> hub;

        public CategoryController(ICategoryLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Category> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Category Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Category value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("CategoryCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Category value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("CategoryUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var categoryToDelete = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("CategoryDeleted", categoryToDelete);
        }
    }
}
