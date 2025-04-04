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

namespace DAL6QM_HFT_2023241.WpfClient.ViewModels
{
    public class PublisherWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Publisher> Publishers { get; set; }

        private Publisher selectedPublisher;

        public Publisher SelectedPublisher
        {
            get { return selectedPublisher; }
            set
            {
                if (value != null)
                {
                    selectedPublisher = new Publisher()
                    {
                        PublisherName = value.PublisherName,
                        PublisherId = value.PublisherId
                    };
                    OnPropertyChanged();
                    (DeletePublisherCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreatePublisherCommand { get; set; }

        public ICommand DeletePublisherCommand { get; set; }

        public ICommand UpdatePublisherCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public PublisherWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Publishers = new RestCollection<Publisher>("http://localhost:33074/", "publisher", "hub");
                CreatePublisherCommand = new RelayCommand(() =>
                {
                    Publishers.Add(new Publisher()
                    {
                        PublisherName = SelectedPublisher.PublisherName,
                    });
                });

                UpdatePublisherCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Publishers.Update(SelectedPublisher);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeletePublisherCommand = new RelayCommand(() =>
                {
                    Publishers.Delete(SelectedPublisher.PublisherId);
                },
                () =>
                {
                    return SelectedPublisher != null;
                });
                SelectedPublisher = new Publisher();
            }
        }
    }
}
