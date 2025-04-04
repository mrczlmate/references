using DAL6QM_HFT_2023241.Endpoint.Services;
using DAL6QM_HFT_2023241.Logic;
using DAL6QM_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace DAL6QM_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookLogic logic;
        IHubContext<SignalRHub> hub;

        public BookController(IBookLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Book> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Book Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Book value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("BookCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Book value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("BookUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var bookToDelete = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("BookDeleted", bookToDelete);
        }
    }
}
