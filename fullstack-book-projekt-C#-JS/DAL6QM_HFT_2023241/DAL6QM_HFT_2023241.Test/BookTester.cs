using DAL6QM_HFT_2023241.Logic;
using DAL6QM_HFT_2023241.Models;
using DAL6QM_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DAL6QM_HFT_2023241.Test
{
    public class BookTester
    {
        BookLogic bookLogic;
        Mock<IRepository<Book>> mockBookRepo;

        [SetUp]
        public void Init()
        {
            mockBookRepo = new Mock<IRepository<Book>>();
            List<Book> books = new List<Book>()
            {
                new Book("1#Harry Potter és a Bölcsek Köve#1#1#6#9990"),
                new Book("2#Harry Potter és a Titkok Kamrája#1#1#6#9990"),
                new Book("3#Harry Potter és az Azkabani Fogoly#1#1#6#8990"),
                new Book("4#Harry Potter és a Tűz Serlege#1#1#6#7550"),
                new Book("5#Harry Potter és a Főnix Rendje#1#1#6#9990"),
                new Book("6#Harry Potter és a Félvér Herceg#1#1#6#8000"),
                new Book("7#Harry Potter és a Halál ereklyéi#1#1#6#5750"),
                new Book("8#Selyemfény#2#1#4#3500"),
                new Book("9#A Cuckoo's Calling#2#1#4#6500"),
                new Book("10#Career of Evil#2#1#3#5590"),
            };

            List<Author> authors = new List<Author>()
            {
                new Author("1#J.K. Rowling"),
                new Author("2#Agatha Christie"),
                new Author("3#J.R.R. Tolkien"),
                new Author("4#Leo Tolstoy"),
            };

            List<Category> categories = new List<Category>()
            {
                new Category("1#Fantasy"),
                new Category("2#Krimi"),
                new Category("3#Gyermek könyv"),
                new Category("4#Regény"),
                new Category("5#Novella"),
            };

            List<Publisher> publishers = new List<Publisher>()
            {
                new Publisher("1#Random House"),
                new Publisher("2#Penguin Books"),
                new Publisher("3#HarperCollins"),
                new Publisher("4#Simon & Schuster"),
                new Publisher("5#Houghton Mifflin Harcourt"),
                new Publisher("6#Macmillan Publishers"),
            };

            var bookhelper = books.AsQueryable();
            mockBookRepo.Setup(b => b.ReadAll()).Returns(bookhelper);
            bookLogic = new BookLogic(mockBookRepo.Object);

            foreach (var b in books)
            {
                b.Author = authors.FirstOrDefault(a => a.AuthorId == b.AuthorId);
            }

            foreach (var b in books)
            {
                b.Publisher = publishers.FirstOrDefault(p => p.PublisherId == b.PublisherId);
            }

            foreach (var b in books)
            {
                b.Category = categories.FirstOrDefault(c => c.CategoryId == b.CategoryId);
            }
        }

        [Test]
        public void CreateBookTestWithCorrectTitle()
        {
            var book = new Book() { Title = "Az" };

            bookLogic.Create(book);

            mockBookRepo.Verify(b => b.Create(book), Times.Once);
        }

        [Test]
        public void CreateBookTestWithIncorrectTitle()
        {
            var book = new Book() { Title = null };

            try
            {
                bookLogic.Create(book);
            }
            catch
            {

            }

            mockBookRepo.Verify(b => b.Create(book), Times.Never);
        }

        [Test]
        public void DeleteBookWithCorrectId()
        {
            int id = 8;

            try
            {
                bookLogic.Delete(id);
            }
            catch
            {

            }

            mockBookRepo.Verify(b => b.Delete(id), Times.Once);
        }

        [Test]
        public void ReadBookWithCorrectId()
        {
            int bookId = 11;

            try
            {
                bookLogic.Read(bookId);
            }
            catch
            {

            }

            mockBookRepo.Verify(b => b.Read(bookId), Times.Once);
        }

        [Test]
        public void ReadBookWithInCorrectId()
        {
            int bookId = 110;

            try
            {
                bookLogic.Read(bookId);
            }
            catch
            {

            }

            mockBookRepo.Verify(b => b.Read(bookId), Times.Once);
        }

        [Test]
        public void AuthorStatisticTest()
        {
            var actual = bookLogic.AuthorStatistic().ToList();
            var expected = new List<BookLogic.AuthorInfo>()
            {
                new BookLogic.AuthorInfo()
                {
                    Name = "J.K. Rowling",
                    BookNumber = 10,
                    AvgPrice = 7585
                }
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PublisherLowestBookTest()
        {
            var actual = bookLogic.PublisherLowestBook().ToList();
            var expected = new List<BookLogic.PublisherMinimum>()
            {
                new BookLogic.PublisherMinimum()
                {
                    PublisherName = "Macmillan Publishers",
                    LowestPrice = 5750
                },
                new BookLogic.PublisherMinimum()
                {
                    PublisherName = "Simon & Schuster",
                    LowestPrice = 3500
                },
                new BookLogic.PublisherMinimum()
                {
                    PublisherName = "HarperCollins",
                    LowestPrice = 5590
                }
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SumBookPricesTest()
        {
            var actual = bookLogic.SumBookPrices().ToList();
            var expected = new List<BookLogic.SumPublisher>()
            {
                new BookLogic.SumPublisher()
                {
                    Name = "Macmillan Publishers",
                    SumPrice = 60260
                },
                new BookLogic.SumPublisher()
                {
                    Name = "Simon & Schuster",
                    SumPrice = 10000
                },
                new BookLogic.SumPublisher()
                {
                    Name = "HarperCollins",
                    SumPrice = 5590
                }
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CategoryStatisticTest()
        {
            var actual = bookLogic.CategoryStatistic().ToList();
            var expected = new List<BookLogic.CategoryInfo>()
            {
                new BookLogic.CategoryInfo()
                {
                    Name = "Fantasy",
                    BookNumber = 7,
                    AvgPrice = 8608.571,
                    MinPrice = 5750,
                    MaxPrice = 9990,
                },
                new BookLogic.CategoryInfo()
                {
                    Name = "Krimi",
                    BookNumber = 3,
                    AvgPrice = 5196.667,
                    MinPrice = 3500,
                    MaxPrice = 6500,
                },
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OrderByPriceBookTest()
        {
            var actual = bookLogic.OrderByPriceBook().ToList();
            var expected = new List<BookLogic.OrderedBook>()
            {
                new BookLogic.OrderedBook()
                {
                    PublisherName = "Macmillan Publishers",
                    CategoryName = "Fantasy",
                    AuthorName = "J.K. Rowling",
                    BookTitle = "Harry Potter és a Bölcsek Köve",
                    Price = 9990
                },
                new BookLogic.OrderedBook()
                {
                    PublisherName = "Macmillan Publishers",
                    CategoryName = "Fantasy",
                    AuthorName = "J.K. Rowling",
                    BookTitle = "Harry Potter és a Titkok Kamrája",
                    Price = 9990
                },
                new BookLogic.OrderedBook()
                {
                    PublisherName = "Macmillan Publishers",
                    CategoryName = "Fantasy",
                    AuthorName = "J.K. Rowling",
                    BookTitle = "Harry Potter és a Főnix Rendje",
                    Price = 9990
                },
                new BookLogic.OrderedBook()
                {
                    PublisherName = "Macmillan Publishers",
                    CategoryName = "Fantasy",
                    AuthorName = "J.K. Rowling",
                    BookTitle = "Harry Potter és az Azkabani Fogoly",
                    Price = 8990
                },
                new BookLogic.OrderedBook()
                {
                    PublisherName = "Macmillan Publishers",
                    CategoryName = "Fantasy",
                    AuthorName = "J.K. Rowling",
                    BookTitle = "Harry Potter és a Félvér Herceg",
                    Price = 8000
                },
                new BookLogic.OrderedBook()
                {
                    PublisherName = "Macmillan Publishers",
                    CategoryName = "Fantasy",
                    AuthorName = "J.K. Rowling",
                    BookTitle = "Harry Potter és a Tűz Serlege",
                    Price = 7550
                },
                new BookLogic.OrderedBook()
                {
                    PublisherName = "Simon & Schuster",
                    CategoryName = "Krimi",
                    AuthorName = "J.K. Rowling",
                    BookTitle = "A Cuckoo's Calling",
                    Price = 6500
                },
                new BookLogic.OrderedBook()
                {
                    PublisherName = "Macmillan Publishers",
                    CategoryName = "Fantasy",
                    AuthorName = "J.K. Rowling",
                    BookTitle = "Harry Potter és a Halál ereklyéi",
                    Price = 5750
                },
                new BookLogic.OrderedBook()
                {
                    PublisherName = "HarperCollins",
                    CategoryName = "Krimi",
                    AuthorName = "J.K. Rowling",
                    BookTitle = "Career of Evil",
                    Price = 5590
                },
                new BookLogic.OrderedBook()
                {
                    PublisherName = "Simon & Schuster",
                    CategoryName = "Krimi",
                    AuthorName = "J.K. Rowling",
                    BookTitle = "Selyemfény",
                    Price = 3500
                }
            };

            Assert.AreEqual(expected, actual);
        }
    }
}
