using DAL6QM_HFT_2023241.Models;
using DAL6QM_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL6QM_HFT_2023241.Logic
{
    public class BookLogic : IBookLogic
    {
        IRepository<Book> _repo;

        public BookLogic(IRepository<Book> repo)
        {
            _repo = repo;
        }

        public void Create(Book item)
        {
            if (item.Title == null)
            {
                throw new ArgumentNullException("Book title can't be null!");
            }
            _repo.Create(item);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public Book Read(int id)
        {
            var book = _repo.Read(id);
            if (book == null)
            {
                throw new ArgumentNullException("Book not exists!");
            }
            return book;
        }

        public IQueryable<Book> ReadAll()
        {
            return _repo.ReadAll();
        }

        public void Update(Book item)
        {
            _repo.Update(item);
        }

        public IEnumerable<AuthorInfo> AuthorStatistic()
        {
            return from a in _repo.ReadAll()
                   group a by a.Author.Name into x
                   select new AuthorInfo()
                   {
                       Name = x.Key,
                       BookNumber = x.Count(),
                       AvgPrice = Math.Round(x.Average(b => b.Price), 3)
                   };
        }

        public IEnumerable<PublisherMinimum> PublisherLowestBook()
        {
            return from p in _repo.ReadAll()
                   group p by p.Publisher.PublisherName into x
                   select new PublisherMinimum()
                   {
                       PublisherName = x.Key,
                       LowestPrice = x.Min(b => b.Price)
                   };
        }

        public IEnumerable<SumPublisher> SumBookPrices()
        {
            return from p in _repo.ReadAll()
                   group p by p.Publisher.PublisherName into x
                   select new SumPublisher()
                   {
                       Name = x.Key,
                       SumPrice = x.Sum(b => b.Price)
                   };
        }

        public IEnumerable<CategoryInfo> CategoryStatistic()
        {
            return from c in _repo.ReadAll()
                   group c by c.Category.CategoryName into x
                   select new CategoryInfo()
                   {
                       Name = x.Key,
                       BookNumber = x.Count(),
                       AvgPrice = Math.Round(x.Average(b => b.Price), 3),
                       MinPrice = x.Min(b => b.Price),
                       MaxPrice = x.Max(b => b.Price)
                   };
        }

        public IEnumerable<OrderedBook> OrderByPriceBook()
        {
            return from a in _repo.ReadAll()
                   orderby a.Price descending
                   select new OrderedBook()
                   {
                       PublisherName = a.Publisher.PublisherName,
                       CategoryName = a.Category.CategoryName,
                       AuthorName = a.Author.Name,
                       BookTitle = a.Title,
                       Price = a.Price,
                   };
        }

        public class OrderedBook
        {
            public OrderedBook()
            {
            }

            public string PublisherName { get; set; }
            public string CategoryName { get; set; }
            public string AuthorName { get; set; }
            public string BookTitle { get; set; }
            public int Price { get; set; }

            public override bool Equals(object obj)
            {
                OrderedBook b = obj as OrderedBook;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.PublisherName == b.PublisherName &&
                        this.CategoryName == b.CategoryName &&
                        this.AuthorName == b.AuthorName &&
                        this.BookTitle == b.BookTitle &&
                        this.Price == b.Price;
                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.PublisherName, this.CategoryName, this.AuthorName, this.BookTitle, this.Price);
            }
        }

        public class CategoryInfo
        {
            public CategoryInfo()
            {
            }

            public string Name { get; set; }
            public int BookNumber { get; set; }
            public double AvgPrice { get; set; }
            public int MinPrice { get; set; }
            public int MaxPrice { get; set; }

            public override bool Equals(object obj)
            {
                CategoryInfo b = obj as CategoryInfo;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.Name == b.Name &&
                        this.BookNumber == b.BookNumber &&
                        this.AvgPrice == b.AvgPrice &&
                        this.MinPrice == b.MinPrice &&
                        this.MaxPrice == b.MaxPrice;
                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.Name, this.BookNumber, this.AvgPrice, this.MinPrice, this.MaxPrice);
            }
        }

        public class SumPublisher
        {
            public SumPublisher()
            {
            }

            public string Name { get; set; }
            public int SumPrice { get; set; }

            public override bool Equals(object obj)
            {
                SumPublisher b = obj as SumPublisher;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.Name == b.Name &&
                        this.SumPrice == b.SumPrice;
                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.Name, this.SumPrice);
            }
        }

        public class PublisherMinimum
        {
            public PublisherMinimum()
            {
            }

            public string PublisherName { get; set; }
            public int LowestPrice { get; set; }

            public override bool Equals(object obj)
            {
                PublisherMinimum b = obj as PublisherMinimum;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.PublisherName == b.PublisherName &&
                        this.LowestPrice == b.LowestPrice;
                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.PublisherName, this.LowestPrice);
            }
        }

        public class AuthorInfo
        {
            public AuthorInfo()
            {
            }

            public string Name { get; set; }
            public int BookNumber { get; set; }
            public double AvgPrice { get; set; }

            public override bool Equals(object obj)
            {
                AuthorInfo b = obj as AuthorInfo;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.Name == b.Name &&
                        this.BookNumber == b.BookNumber &&
                        this.AvgPrice == b.AvgPrice;
                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.Name, this.BookNumber, this.AvgPrice);
            }
        }
    }
}
