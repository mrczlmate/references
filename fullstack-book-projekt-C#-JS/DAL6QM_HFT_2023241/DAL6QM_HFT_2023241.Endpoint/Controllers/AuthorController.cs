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
    public class AuthorController : ControllerBase
    {
        IAuthorLogic logic;
        IHubContext<SignalRHub> hub;

        public AuthorController(IAuthorLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Author> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Author Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Author value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("AuthorCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Author value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("AuthorUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var authorToDelete= this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("AuthorDeleted", authorToDelete);
        }
    }
}
