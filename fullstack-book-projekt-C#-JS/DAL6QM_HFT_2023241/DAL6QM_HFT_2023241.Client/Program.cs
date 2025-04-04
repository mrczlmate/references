using ConsoleTools;
using DAL6QM_HFT_2023241.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace DAL6QM_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;

        static void Create(string entity)
        {
            if (entity == "Book")
            {
                Console.Write("Enter Book Title: ");
                string title = Console.ReadLine();
                rest.Post(new Book() { Title = title }, "book");
            }
            else if (entity == "Author")
            {
                Console.Write("Enter Author Name: ");
                string name = Console.ReadLine();
                rest.Post(new Author() { Name = name }, "author");
            }
            else if (entity == "Publisher")
            {
                Console.Write("Enter Publisher Name: ");
                string name = Console.ReadLine();
                rest.Post(new Publisher() { PublisherName = name }, "publisher");
            }
            else if (entity == "Category")
            {
                Console.Write("Enter Category Name: ");
                string name = Console.ReadLine();
                rest.Post(new Category() { CategoryName = name }, "category");
            }
        }

        static void List(string entity)
        {
            if (entity == "Book")
            {
                List<Book> books = rest.Get<Book>("book");
                foreach (var item in books)
                {
                    Console.WriteLine($"{item.BookId}: {item.Title}");
                }
            }
            else if (entity == "Author")
            {
                List<Author> authors = rest.Get<Author>("author");
                foreach (var item in authors)
                {
                    Console.WriteLine($"{item.AuthorId}: {item.Name}");
                }
            }
            else if (entity == "Publisher")
            {
                List<Publisher> publishers = rest.Get<Publisher>("publisher");
                foreach (var item in publishers)
                {
                    Console.WriteLine($"{item.PublisherId}: {item.PublisherName}");
                }
            }
            else if (entity == "Category")
            {
                List<Category> categories = rest.Get<Category>("category");
                foreach (var item in categories)
                {
                    Console.WriteLine($"{item.CategoryId}: {item.CategoryName}");
                }
            }
            Console.ReadLine();
        }

        static void Update(string entity)
        {
            if (entity == "Book")
            {
                Console.Write("Enter Book's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Book old = rest.Get<Book>(id, "book");
                Console.Write($"New title[old: {old.Title}]: ");
                string title = Console.ReadLine();
                old.Title = title;
                rest.Put(old, "book");
            }
            else if (entity == "Author")
            {
                Console.Write("Enter Author's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Author old = rest.Get<Author>(id, "author");
                Console.Write($"New name[old: {old.Name}]: ");
                string name = Console.ReadLine();
                old.Name = name;
                rest.Put(old, "author");
            }
            else if (entity == "Publisher")
            {
                Console.Write("Enter Publisher's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Publisher old = rest.Get<Publisher>(id, "publisher");
                Console.Write($"New name[old: {old.PublisherName}]: ");
                string name = Console.ReadLine();
                old.PublisherName = name;
                rest.Put(old, "publisher");
            }
            else if (entity == "Category")
            {
                Console.Write("Enter Category's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Category old = rest.Get<Category>(id, "category");
                Console.Write($"New name[old: {old.CategoryName}]: ");
                string name = Console.ReadLine();
                old.CategoryName = name;
                rest.Put(old, "category");
            }
        }

        static void Delete(string entity)
        {
            if (entity == "Book")
            {
                Console.Write("Enter Book's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "book");
            }
            else if (entity == "Author")
            {
                Console.Write("Enter Author's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "author");
            }
            else if (entity == "Publisher")
            {
                Console.Write("Enter Publisher's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "publisher");
            }
            else if (entity == "Category")
            {
                Console.Write("Enter Category's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "category");
            }
        }

        static void Stat(string entity)
        {
            List<JToken> result = rest.Get<JToken>($"Stat/{entity}");
            int i = 1;
            foreach (JToken item in result)
            {
                Console.WriteLine($"{i}:");
                var props = item.Values();
                foreach (JToken prop in props)
                {
                    Console.WriteLine($"{prop.Path}: {prop}");
                }
                i++;
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:33074/", "book");

            var bookSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Book"))
                .Add("Create", () => Create("Book"))
                .Add("Delete", () => Delete("Book"))
                .Add("Update", () => Update("Book"))
                .Add("Exit", ConsoleMenu.Close);

            var authorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Author"))
                .Add("Create", () => Create("Author"))
                .Add("Delete", () => Delete("Author"))
                .Add("Update", () => Update("Author"))
                .Add("Exit", ConsoleMenu.Close);

            var publisherSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Publisher"))
                .Add("Create", () => Create("Publisher"))
                .Add("Delete", () => Delete("Publisher"))
                .Add("Update", () => Update("Publisher"))
                .Add("Exit", ConsoleMenu.Close);

            var categorySubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Category"))
                .Add("Create", () => Create("Category"))
                .Add("Delete", () => Delete("Category"))
                .Add("Update", () => Update("Category"))
                .Add("Exit", ConsoleMenu.Close);

            var statSubMenu = new ConsoleMenu(args, level: 1)
                .Add("AuthorStatistic", () => Stat("AuthorStatistic"))
                .Add("PublisherLowestBook", () => Stat("PublisherLowestBook"))
                .Add("SumBookPrices", () => Stat("SumBookPrices"))
                .Add("CategoryStatistic", () => Stat("CategoryStatistic"))
                .Add("OrderByPriceBook", () => Stat("OrderByPriceBook"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Books", () => bookSubMenu.Show())
                .Add("Authors", () => authorSubMenu.Show())
                .Add("Publishers", () => publisherSubMenu.Show())
                .Add("Categories", () => categorySubMenu.Show())
                .Add("Non-CRUD statistics", () => statSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
