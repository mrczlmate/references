﻿using DAL6QM_HFT_2023241.Models;
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
using System.Numerics;

namespace DAL6QM_HFT_2023241.WpfClient.ViewModels
{
    public class AuthorWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Author> Authors { get; set; }

        private Author selectedAuthor;

        public Author SelectedAuthor
        {
            get { return selectedAuthor; }
            set
            {
                if (value != null)
                {
                    selectedAuthor = new Author()
                    {
                        Name = value.Name,
                        AuthorId = value.AuthorId
                    };
                    OnPropertyChanged();
                    (DeleteAuthorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateAuthorCommand { get; set; }

        public ICommand DeleteAuthorCommand { get; set; }

        public ICommand UpdateAuthorCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public AuthorWindowViewModel() 
        {
            if (!IsInDesignMode)
            {
                Authors = new RestCollection<Author>("http://localhost:33074/", "author", "hub");
                CreateAuthorCommand = new RelayCommand(() =>
                {
                    Authors.Add(new Author()
                    {
                        Name = SelectedAuthor.Name,
                    });
                });

                UpdateAuthorCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Authors.Update(SelectedAuthor);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteAuthorCommand = new RelayCommand(() =>
                {
                    Authors.Delete(SelectedAuthor.AuthorId);
                },
                () =>
                {
                    return SelectedAuthor != null;
                });
                SelectedAuthor = new Author();
            }
        }
    }
}
