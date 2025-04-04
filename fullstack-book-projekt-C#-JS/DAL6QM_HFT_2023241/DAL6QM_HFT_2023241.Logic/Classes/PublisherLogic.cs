using DAL6QM_HFT_2023241.Models;
using DAL6QM_HFT_2023241.Repository;
using System;
using System.Linq;

namespace DAL6QM_HFT_2023241.Logic
{
    public class PublisherLogic : IPublisherLogic
    {
        IRepository<Publisher> _repo;

        public PublisherLogic(IRepository<Publisher> repo)
        {
            _repo = repo;
        }

        public void Create(Publisher item)
        {
            if (item.PublisherName == null)
            {
                throw new ArgumentNullException("Publisher name can't be null!");
            }
            _repo.Create(item);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public Publisher Read(int id)
        {
            var publisher = _repo.Read(id);
            if (publisher == null)
            {
                throw new ArgumentNullException("Publisher not exists!");
            }
            return publisher;
        }

        public IQueryable<Publisher> ReadAll()
        {
            return _repo.ReadAll();
        }

        public void Update(Publisher item)
        {
            _repo.Update(item);
        }
    }
}
