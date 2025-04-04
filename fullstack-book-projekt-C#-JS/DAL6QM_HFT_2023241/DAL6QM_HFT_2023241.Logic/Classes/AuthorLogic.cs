using DAL6QM_HFT_2023241.Models;
using DAL6QM_HFT_2023241.Repository;
using System;
using System.Linq;

namespace DAL6QM_HFT_2023241.Logic
{
    public class AuthorLogic : IAuthorLogic
    {
        IRepository<Author> _repo;

        public AuthorLogic(IRepository<Author> repo)
        {
            _repo = repo;
        }

        public void Create(Author item)
        {
            if (item.Name == null)
            {
                throw new ArgumentException("Author name can't be null!");
            }
            _repo.Create(item);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public Author Read(int id)
        {
            var author = _repo.Read(id);
            if (author == null)
            {
                throw new ArgumentNullException("Author not exists!");
            }
            return author;
        }

        public IQueryable<Author> ReadAll()
        {
            return _repo.ReadAll();
        }

        public void Update(Author item)
        {
            _repo.Update(item);
        }
    }
}
