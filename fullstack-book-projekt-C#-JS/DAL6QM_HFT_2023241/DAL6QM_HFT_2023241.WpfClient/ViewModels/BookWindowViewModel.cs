using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using DAL6QM_HFT_2023241.Models;
using System.Numerics;
using Newtonsoft.Json.Linq;

namespace DAL6QM_HFT_2023241.WpfClient.ViewModels
{
    public class BookWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Book> Books { get; set; }

        private Book selectedBook;

        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                if (value != null)
                {
                    selectedBook = new Book()
                    {
                        BookId = value.BookId,
                        Title = value.Title,
                        Price = value.Price,
                        CategoryId = value.CategoryId,
                        AuthorId = value.AuthorId,
                        PublisherId = value.PublisherId,
                    };
                    OnPropertyChanged();
                    (DeleteBookCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateBookCommand { get; set; }

        public ICommand DeleteBookCommand { get; set; }

        public ICommand UpdateBookCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public BookWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Books = new RestCollection<Book>("http://localhost:33074/", "book", "hub");
                CreateBookCommand = new RelayCommand(() =>
                {
                    Books.Add(new Book()
                    {
                        Title = SelectedBook.Title,
                        Price = SelectedBook.Price,
                        CategoryId = SelectedBook.CategoryId,
                        AuthorId = SelectedBook.AuthorId,
                        PublisherId = SelectedBook.PublisherId,
                    });
                });

                UpdateBookCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Books.Update(SelectedBook);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteBookCommand = new RelayCommand(() =>
                {
                    Books.Delete(SelectedBook.BookId);
                },
                () =>
                {
                    return SelectedBook != null;
                });
                SelectedBook = new Book();
            }

        }
    }
}
