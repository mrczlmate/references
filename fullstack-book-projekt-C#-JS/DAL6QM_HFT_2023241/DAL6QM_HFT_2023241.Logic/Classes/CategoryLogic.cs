using DAL6QM_HFT_2023241.Models;
using DAL6QM_HFT_2023241.Repository;
using System;
using System.Linq;

namespace DAL6QM_HFT_2023241.Logic
{
    public class CategoryLogic : ICategoryLogic
    {
        IRepository<Category> _repo;

        public CategoryLogic(IRepository<Category> repo)
        {
            _repo = repo;
        }

        public void Create(Category item)
        {
            if (item.CategoryName == null)
            {
                throw new ArgumentNullException("Category name can't be null!");
            }
            _repo.Create(item);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public Category Read(int id)
        {
            var category = _repo.Read(id);
            if (category == null)
            {
                throw new ArgumentNullException("Category not exists!");
            }
            return category;
        }

        public IQueryable<Category> ReadAll()
        {
            return _repo.ReadAll();
        }

        public void Update(Category item)
        {
            _repo.Update(item);
        }
    }
}
