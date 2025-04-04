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

namespace DAL6QM_HFT_2023241.WpfClient.ViewModels
{
    public class CategoryWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Category> Categories { get; set; }

        private Category selectedCategory;

        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                if (value != null)
                {
                    selectedCategory = new Category()
                    {
                        CategoryName = value.CategoryName,
                        CategoryId = value.CategoryId
                    };
                    OnPropertyChanged();
                    (DeleteCategoryCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateCategoryCommand { get; set; }

        public ICommand DeleteCategoryCommand { get; set; }

        public ICommand UpdateCategoryCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public CategoryWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Categories = new RestCollection<Category>("http://localhost:33074/", "category", "hub");
                CreateCategoryCommand = new RelayCommand(() =>
                {
                    Categories.Add(new Category()
                    {
                        CategoryName = SelectedCategory.CategoryName
                    });
                });

                UpdateCategoryCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Categories.Update(SelectedCategory);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteCategoryCommand = new RelayCommand(() =>
                {
                    Categories.Delete(SelectedCategory.CategoryId);
                },
                () =>
                {
                    return SelectedCategory != null;
                });
                SelectedCategory = new Category();
            }

        }
    }
}
