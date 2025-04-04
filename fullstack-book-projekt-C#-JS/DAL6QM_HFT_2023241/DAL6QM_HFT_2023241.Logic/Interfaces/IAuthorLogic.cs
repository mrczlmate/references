using DAL6QM_HFT_2023241.Models;
using System.Linq;

namespace DAL6QM_HFT_2023241.Logic
{
    public interface IAuthorLogic
    {
        void Create(Author item);
        void Delete(int id);
        Author Read(int id);
        IQueryable<Author> ReadAll();
        void Update(Author item);
    }
}