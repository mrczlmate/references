using DAL6QM_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL6QM_HFT_2023241.Logic
{
    public interface IBookLogic
    {
        IEnumerable<BookLogic.AuthorInfo> AuthorStatistic();
        IEnumerable<BookLogic.CategoryInfo> CategoryStatistic();
        void Create(Book item);
        void Delete(int id);
        IEnumerable<BookLogic.OrderedBook> OrderByPriceBook();
        IEnumerable<BookLogic.PublisherMinimum> PublisherLowestBook();
        Book Read(int id);
        IQueryable<Book> ReadAll();
        IEnumerable<BookLogic.SumPublisher> SumBookPrices();
        void Update(Book item);
    }
}