using DAL6QM_HFT_2023241.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DAL6QM_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IBookLogic logic;

        public StatController(IBookLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<BookLogic.AuthorInfo> AuthorStatistic()
        {
            return logic.AuthorStatistic();
        }

        [HttpGet]
        public IEnumerable<BookLogic.PublisherMinimum> PublisherLowestBook()
        {
            return logic.PublisherLowestBook();
        }

        [HttpGet]
        public IEnumerable<BookLogic.SumPublisher> SumBookPrices()
        {
            return logic.SumBookPrices();
        }

        [HttpGet]
        public IEnumerable<BookLogic.CategoryInfo> CategoryStatistic()
        {
            return logic.CategoryStatistic();
        }

        [HttpGet]
        public IEnumerable<BookLogic.OrderedBook> OrderByPriceBook()
        {
            return logic.OrderByPriceBook();
        }
    }
}
