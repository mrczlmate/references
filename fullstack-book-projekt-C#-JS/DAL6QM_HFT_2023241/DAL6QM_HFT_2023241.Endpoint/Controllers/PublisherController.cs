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
    public class PublisherController : ControllerBase
    {
        IPublisherLogic logic;
        IHubContext<SignalRHub> hub;

        public PublisherController(IPublisherLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Publisher> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Publisher Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Publisher value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("PublisherCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Publisher value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("PublisherUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var publisherToDelete = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("PublisherDeleted", publisherToDelete);
        }
    }
}
