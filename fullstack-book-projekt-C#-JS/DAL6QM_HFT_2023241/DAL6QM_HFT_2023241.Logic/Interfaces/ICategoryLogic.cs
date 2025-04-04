using DAL6QM_HFT_2023241.Models;
using System.Linq;

namespace DAL6QM_HFT_2023241.Logic
{
    public interface ICategoryLogic
    {
        void Create(Category item);
        void Delete(int id);
        Category Read(int id);
        IQueryable<Category> ReadAll();
        void Update(Category item);
    }
}